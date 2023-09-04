using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsEnemyCharacter : AbsCharacter
{
    [SerializeField] private CharacterInfo _characterInfo;

    public override void Awake()
    {
        _currentCharacterInfo = _characterInfo;
        base.Awake();
    }
}
