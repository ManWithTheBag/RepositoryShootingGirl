using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeAim : AbsTakeAimCharacter
{
    public override void CheckAngleTakeAim()
    {
        _currentAngle = Vector3.Angle(Vector3.back, _absWeapon.CalculateAimDirection());

        if (_currentAngle < _angleLimitTakeAim)
            _aimDirection = _absWeapon.CalculateAimDirection();
        else
            _aimDirection = Vector3.back;
    }
}
