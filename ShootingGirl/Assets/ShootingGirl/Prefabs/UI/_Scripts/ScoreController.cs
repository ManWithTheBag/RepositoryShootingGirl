using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private CommonGameInfo _commonGameInfo;

    private Coroutine _scoreCoroutine;
    private bool _isDoCoroutine;
    private float _currentLerpValue;
    private int _updatedScore;
    private int _oldScore;

    public int currentScore { get { return _updatedScore; }private set { _updatedScore = value; }}

    private void Start()
    {
        _updatedScore = 0;
        _scoreText.text = _updatedScore.ToString();
    }

    public void AddScore(int addScore)
    {
        _oldScore = _updatedScore;
        _updatedScore += addScore;
        LerpScore(_oldScore, _updatedScore);

    }

    public void LoseScore(int loseScore)
    {
        _oldScore = _updatedScore;
        _updatedScore -= loseScore;
        LerpScore(_oldScore, _updatedScore);
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

        for (float i = 0; i < 1; i += Time.deltaTime / _commonGameInfo.timeLerpingValue)
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
