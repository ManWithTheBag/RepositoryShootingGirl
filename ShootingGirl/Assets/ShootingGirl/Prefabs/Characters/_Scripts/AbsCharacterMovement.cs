using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsCharacterMovement : MonoBehaviour
{
    [SerializeField]protected Transform _bodyCharacter;

    protected AbsCharacter _thisCharacter;
    protected Transform _mapCenter;
    protected Transform _thisTransform;
    protected Vector3 _directionMovement = new Vector3();
    protected Rigidbody _thisRb;
    protected Transform _aimTransform;
    private Vector3 _aimDirection;

    public Transform AimTransform { get { return _aimTransform; } private set { _aimTransform = value; } }


    public virtual void  Awake()
    {
        _thisTransform = transform;
        _mapCenter = GameObject.Find("MapCenter").transform;
        _thisCharacter = GetComponent<AbsCharacter>();
        _thisRb = GetComponent<Rigidbody>();

        SetStartPosition();
    }

    public virtual void Start()
    {
        SetAimTransform();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    public abstract void SetStartPosition();

    public abstract void SetAimTransform();

    public abstract void MoveCharacter();

    private void LateUpdate()
    {
        RotationTurret();
    }

    private void RotationTurret()
    {
        _aimDirection = (_aimTransform.position - _thisTransform.position);
        _bodyCharacter.rotation = Quaternion.Lerp(_bodyCharacter.rotation, Quaternion.LookRotation(_aimDirection), Time.deltaTime * _thisCharacter.CharacterInfo.SpeedTakeAim);
    }

}
