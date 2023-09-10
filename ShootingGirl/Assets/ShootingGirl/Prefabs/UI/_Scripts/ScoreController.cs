using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameInfo _gameInfo;

    private int _totalScore;
    private int _currentScore;
    private int _oldScore;
    private Coroutine _scoreCoroutine;
    private bool _isDoCoroutine;
    private float _currentLerpValue;

    public int currentScore { get { return _currentScore; }private set { _currentScore = value; }}

    private void Start()
    {
        _currentScore = 0;
        _scoreText.text = _currentScore.ToString();
    }

    public void AddScore(int addScore)
    {
        _oldScore = _currentScore;
        _currentScore += addScore;
        LerpScore(_oldScore, _currentScore);

        GlobalEventManager.UpdatedCurrentScoreEvent?.Invoke(_currentScore);
    }

    public void LoseScore(int loseScore)
    {
        _oldScore = _currentScore;
        _currentScore -= loseScore;
        LerpScore(_oldScore, _currentScore);

        GlobalEventManager.UpdatedCurrentScoreEvent?.Invoke(_currentScore);
    }

    private void LerpScore(float oldValue, float newValue)
    {
        if (_isDoCoroutine == true)
        {
            StopCoroutine(_scoreCoroutine);

            oldValue = Mathf.RoundToInt(_currentLerpValue);
            _scoreCoroutine = StartCoroutine(LerpValue(oldValue, newValue));
        }
        else
        {
            _scoreCoroutine = StartCoroutine(LerpValue(oldValue, newValue));
        }
    }

    private IEnumerator LerpValue(float oldScoreValue, float newScoreValue)
    {
        _isDoCoroutine = true;

        for (float i = 0; i < 1; i += Time.deltaTime / _gameInfo.timeLerpingValue)
        {
            _currentLerpValue = Mathf.Lerp(oldScoreValue, newScoreValue, i);
            GetLerpResult(_currentLerpValue);
            yield return null;
        }

        GetLerpResult(newScoreValue);

        _isDoCoroutine = false;
    }

    private void GetLerpResult(float result)
    {
        _scoreText.text = Mathf.RoundToInt(result).ToString();
    }
}
