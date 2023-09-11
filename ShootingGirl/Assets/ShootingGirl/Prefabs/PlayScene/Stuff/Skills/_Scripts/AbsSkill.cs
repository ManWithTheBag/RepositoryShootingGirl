using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsSkill : MonoBehaviour
{
    [SerializeField] protected MapInfo _mapInfo;
    [SerializeField] protected SkillsInfo _skillsInfo;
    protected ScoreController _scoreController;

    private bool _isScoreEnough;

    public virtual void Awake()
    {
        _scoreController = GameObject.Find("UIController").GetComponent<ScoreController>();
    }

    public virtual void OnEnable()
    {
        GlobalEventManager.UpdatedCurrentScoreEvent.AddListener(CheckLaunchButtonStates);
    }
    public virtual void OnDisable()
    {
        GlobalEventManager.UpdatedCurrentScoreEvent.RemoveListener(CheckLaunchButtonStates);
    }

    protected void CheckLaunchButtonStates(int currentScore)
    {
        if (currentScore >= _skillsInfo.price)
            _isScoreEnough = true;
        else
            _isScoreEnough = false;
    }

    protected void TryToUseSkill()
    {
        if (_isScoreEnough)
        {
            UseSkill();
            _scoreController.LoseScore(_skillsInfo.price);
        }
    }

    public abstract void UseSkill();
}
