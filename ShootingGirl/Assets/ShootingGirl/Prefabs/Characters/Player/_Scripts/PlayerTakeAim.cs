using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeAim : AbsTakeAimCharacter
{
    public override void CheckAngleTakeAim()
    {
        _currentAngle = Vector3.Angle(Vector3.forward, _absWeapon.CalculateAimDirection());

        if (_currentAngle < _angleLimitTakeAim)
            _aimDirection = _absWeapon.CalculateAimDirection();
        else
            _aimDirection = Vector3.forward;
    }
}
