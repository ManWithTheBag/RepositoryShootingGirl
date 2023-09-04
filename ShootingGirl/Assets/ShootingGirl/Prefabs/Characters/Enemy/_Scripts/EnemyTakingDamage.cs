using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakingDamage : AbsTakingDamage
{
    private ScoreController _scoreController;

    public override void Awake()
    {
        _scoreController = GameObject.Find("UIController").GetComponent<ScoreController>();
        base.Awake();
    }


    public override void DeathCharacter()
    {
        _scoreController.AddScore(_thisCharacter.currentCharacterInfo.scoreInEnemy);
        base.DeathCharacter();
    }
}
