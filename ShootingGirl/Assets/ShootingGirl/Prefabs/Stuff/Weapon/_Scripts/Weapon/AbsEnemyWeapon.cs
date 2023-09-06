using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsEnemyWeapon : AbsWeapon
{
    private float _distanceEnemyToPlayer;
    private string _playerTag = "Player";
    RaycastHit _hit;

    private void Start()
    {
        SetAimSootTransform();
    }

    public override void SetAbsCharacter()
    {
        _absCharacter = GetComponent<AbsCharacter>();
    }
    public override void SetAimSootTransform()
    {
        _aimShotTransform = Player.s_playerTransform;
    }

    public override bool CheckPersonalWeaponCondition()
    {
        _distanceEnemyToPlayer = Vector3.Distance(_absCharacter.thisTransform.position, _aimShotTransform.position);

        if (_distanceEnemyToPlayer < _weaponInfo.range)
        {
            if (Physics.Raycast(_firePosition.position, _aimDirection, out _hit, _weaponInfo.range))
            {
                if (_hit.transform.CompareTag(_playerTag))
                {
                    return true;
                }
            }
        }

        return false;
    }
}
