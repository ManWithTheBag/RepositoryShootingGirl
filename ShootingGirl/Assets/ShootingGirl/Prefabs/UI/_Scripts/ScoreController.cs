using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private CommonGameInfo _commonGameInfo;

    private bool _isDoCoroutine;
    private int _updatedScore;
    private int _oldScore;
    private float _currentLerpScore;
    private LerpValue _lerpValue;

    public int currentScore { get { return _updatedScore; }private set { _updatedScore = value; }}

    private void Awake()
    {
        _lerpValue = new LerpValue(_commonGameInfo.timeLerpingValue);
    }

    private void OnEnable()
    {
        _lerpValue.LerpChengedValueEvent += CheckResult;
    }
    private void OnDisable()
    {
        _lerpValue.LerpChengedValueEvent -= CheckResult;
    }


    private void Start()
    {
        _updatedScore = 0;
        _scoreText.text = _updatedScore.ToString();
    }

    public void AddScore(int addScore)
    {
        _oldScore = _updatedScore;
        _updatedScore += addScore;
        //RefreshScore(_oldScore, _updatedScore);
        test(_oldScore, _updatedScore);

    }

    public void LoseScore(int loseScore)
    {
        _oldScore = _updatedScore;
        _updatedScore -= loseScore;
        //RefreshScore(_oldScore, _updatedScore);
        test(_oldScore, _updatedScore);
    }

    private void test(int oldScoreValue, int newScoreValue)
    {
        _lerpValue.SetNewValue(oldScoreValue, newScoreValue);
    }

    private void CheckResult(float result)
    {
        _scoreText.text = Mathf.RoundToInt(result).ToString();
    }


    //private void RefreshScore(int oldScoreValue, int newScoreValue)
    //{
    //    if (_isDoCoroutine == true)
    //    {
    //        StopCoroutine(LerpingScore(oldScoreValue, newScoreValue));

    //        oldScoreValue = Mathf.RoundToInt(_currentLerpScore);
    //        StartCoroutine(LerpingScore(oldScoreValue, newScoreValue));
    //    }
    //    else
    //    {
    //        StartCoroutine(LerpingScore(oldScoreValue, newScoreValue));
    //    }
    //}


    //private IEnumerator LerpingScore(int oldScoreValue, int newScoreValue)
    //{
    //    _isDoCoroutine = true;

    //    for (float i = 0; i < 1; i += Time.deltaTime / _timeLerpingScore)
    //    {
    //        _currentLerpScore = Mathf.Lerp(oldScoreValue, newScoreValue, i);
    //        _scoreText.text = Mathf.Round(_currentLerpScore).ToString();
    //        yield return null;
    //    }

    //    _scoreText.text = _updatedScore.ToString();

    //    _isDoCoroutine = false;
    //}
}
