using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRocket : AbsPlayerWeapon
{
    private bool _isShot;
    private float _currentLerpValue;

    public override void OnEnable()
    {
        base.OnEnable();
        _playerButtonController.shotButton.ShotButtonOnClickEvent += ShotPlayerRocket;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        _playerButtonController.shotButton.ShotButtonOnClickEvent -= ShotPlayerRocket;
    }

    public override void SetPoolShellForWeapon()
    {
        _poolCurrentShell = _shellPoolContainer.poolShelRocket;
    }

    public override bool CheckPersonalWeaponCondition()
    {
        return false;
    }


    private void ShotPlayerRocket()
    {
        if (!_isShot)
        {
            Shot();
            _isShot = true;

            SetLerpValue(0, 1, false);
        }

    }

    public override void SetLerpValue(float currentValue, float defaultValue, bool isRevers)
    {
        StartCoroutine(LerpValue(currentValue, defaultValue));
    }

    private IEnumerator LerpValue(float oldScoreValue, float newScoreValue)
    {
        for (float i = 0; i < 1; i += Time.deltaTime / _weaponInfo.timeRechargeShell)
        {
            _currentLerpValue = Mathf.Lerp(oldScoreValue, newScoreValue, i);
            GetLerpResult(_currentLerpValue);
            yield return null;
        }

        GetLerpResult(0);
        _isShot = false;
    }

    private void GetLerpResult(float result)
    {
        _playerButtonController.overheatFillImage.fillAmount = result;
    }


}
