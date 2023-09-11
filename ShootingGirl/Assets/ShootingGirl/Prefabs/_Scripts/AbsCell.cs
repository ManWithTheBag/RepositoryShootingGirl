using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsCell : MonoBehaviour
{
    protected CharacterInfo _characterInfo;
    protected AbsPlayerBaseModetState _absPlayerBaseModetState;
    protected Transform _cellTransform;

    public CharacterInfo characterInfo { get { return _characterInfo; } private set { _characterInfo = value; } }
    public AbsPlayerBaseModetState absPlayerBaseModetState { get { return _absPlayerBaseModetState; } private set { _absPlayerBaseModetState = value; } }
    public Transform cellTransform { get { return _cellTransform; } private set { _cellTransform = value; } }


    public virtual void Awake()
    {
        _cellTransform = transform;
    }

    public virtual void SetupPlayerModelCell(AbsPlayerBaseModetState absPlayerBaseModetState)
    {
        _absPlayerBaseModetState = absPlayerBaseModetState;
        _characterInfo = absPlayerBaseModetState.characterInfo;
    }
}
