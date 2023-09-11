using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeAim : AbsTakeAimCharacter
{
    private bool _isPlayerDied;

    private void OnEnable()
    {
        GlobalEventManager.DiedPlayerEvent.AddListener(SetPlayerStatus);   
    }
    private void OnDisable()
    {
        GlobalEventManager.DiedPlayerEvent.RemoveListener(SetPlayerStatus);
    }

    private void SetPlayerStatus()
    {
        _isPlayerDied = true;
    }

    public override void CheckAngleTakeAim()
    {
        _currentAngle = Vector3.Angle(Vector3.back, _absWeapon.CalculateAimDirection());

        if (_currentAngle < _angleLimitTakeAim && _isPlayerDied == false)
            _aimDirection = _absWeapon.CalculateAimDirection();
        else
            _aimDirection = Vector3.back;
    }
}
