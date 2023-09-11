using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsTakeAimCharacter : MonoBehaviour
{
    [SerializeField] protected float _angleLimitTakeAim;
    [SerializeField] protected Transform _bodyCharacter;
    [SerializeField] private Transform _weaponModel;

    protected AbsWeapon _absWeapon;
    protected float _currentAngle;
    protected Vector3 _aimDirection;
    private Transform _thisTransform;

    private void Awake()
    {
        _absWeapon = GetComponent<AbsWeapon>();
        _thisTransform = transform;
    }

    private void Update()
    {
        CheckAngleTakeAim();

        TakeAimVeaponModel();
        TakeAimBody();
    }

    public abstract void CheckAngleTakeAim();

    private void TakeAimVeaponModel()
    {
        _weaponModel.rotation = Quaternion.Lerp(_weaponModel.rotation, Quaternion.LookRotation(_aimDirection), Time.fixedDeltaTime * _absWeapon.weaponInfo.speedTrakeAim);
    }
    private void TakeAimBody()
    {
        _bodyCharacter.rotation = Quaternion.Lerp(_bodyCharacter.rotation, Quaternion.LookRotation(_aimDirection), Time.fixedDeltaTime * _absWeapon.weaponInfo.speedTrakeAim);
    }
}
