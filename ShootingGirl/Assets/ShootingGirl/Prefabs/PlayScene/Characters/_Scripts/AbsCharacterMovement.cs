using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsCharacterMovement : MonoBehaviour
{
    protected AbsCharacter _thisCharacter;
    protected Transform _mapCenter;
    protected Transform _thisTransform;
    protected Vector3 _directionMovement = new Vector3();
    protected Rigidbody _thisRb;
    protected Transform _aimTransform;

    public Transform thisCharacterTransform { get { return _thisTransform; } private set { _thisTransform = value; } }

    public virtual void  Awake()
    {
        _thisTransform = transform;
        _mapCenter = GameObject.Find("MapCenter").transform;
        _thisCharacter = GetComponent<AbsCharacter>();
        _thisRb = GetComponent<Rigidbody>();

        SetStartPosition();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    public abstract void SetStartPosition();

    public abstract void MoveCharacter();
}
