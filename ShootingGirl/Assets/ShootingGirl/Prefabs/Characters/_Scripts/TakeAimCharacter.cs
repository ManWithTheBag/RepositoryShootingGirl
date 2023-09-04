using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAimCharacter : MonoBehaviour
{
    [SerializeField] private Transform _bodyCharacter;
    [SerializeField] private Transform _weaponModel;


    private Transform _thisTransform;
    private Vector3 _aimDirection;
    private AbsWeapon _absWeapon;

    private void Awake()
    {
        _absWeapon = GetComponent<AbsWeapon>();
        _thisTransform = transform;
    }

    private void Update()
    {
        TakeAimVeaponModel();
        TakeAimBody();
    }
    private void TakeAimVeaponModel()
    {
        _aimDirection = (_absWeapon.aimShotTransform.position - _weaponModel.position);
        _weaponModel.rotation = Quaternion.Lerp(_weaponModel.rotation, Quaternion.LookRotation(_aimDirection), Time.fixedDeltaTime * _absWeapon.weaponInfo.speedTrakeAim);
    }
    private void TakeAimBody()
    {
        _aimDirection = (_absWeapon.aimShotTransform.position - _thisTransform.position);
        _bodyCharacter.rotation = Quaternion.Lerp(_bodyCharacter.rotation, Quaternion.LookRotation(_aimDirection), Time.fixedDeltaTime * _absWeapon.weaponInfo.speedTrakeAim);
    }
}
