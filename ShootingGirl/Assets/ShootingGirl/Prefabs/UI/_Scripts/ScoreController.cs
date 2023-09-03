using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private CommonGameInfo _commonGameInfo;

    private int _updatedScore;
    private int _oldScore;
    private LerpValue _lerpValue;

    public int currentScore { get { return _updatedScore; }private set { _updatedScore = value; }}

    private void Awake()
    {
        _lerpValue = new LerpValue(_commonGameInfo.timeLerpingValue);
    }

    private void OnEnable()
    {
        _lerpValue.LerpChengedValueEvent += GetLerpResult;
    }
    private void OnDisable()
    {
        _lerpValue.LerpChengedValueEvent -= GetLerpResult;
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
        SetLerpValue(_oldScore, _updatedScore);

    }

    public void LoseScore(int loseScore)
    {
        _oldScore = _updatedScore;
        _updatedScore -= loseScore;
        SetLerpValue(_oldScore, _updatedScore);
    }

    private void SetLerpValue(int oldScoreValue, int newScoreValue)
    {
        _lerpValue.SetNewValue(oldScoreValue, newScoreValue);
    }

    private void GetLerpResult(float result)
    {
        _scoreText.text = Mathf.RoundToInt(result).ToString();
    }
}
