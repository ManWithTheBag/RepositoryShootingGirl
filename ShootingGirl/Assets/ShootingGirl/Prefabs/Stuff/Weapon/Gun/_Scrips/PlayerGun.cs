using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : AbsWeapon
{
    [SerializeField] private CommonGameInfo _commonGameInfo;
    private PlayerButtonController _shotPlayer;
    private bool _shotStatus;


    public override void Awake()
    {
        base.Awake();
        _shotPlayer = GameObject.Find("UIController").GetComponent<PlayerButtonController>();
    }

    private void OnEnable()
    {
        _shotPlayer.shotButton.ShotButtonStatusEvent += SetPlayerShotStatus;
    }
    private void OnDisable()
    {
        _shotPlayer.shotButton.ShotButtonStatusEvent -= SetPlayerShotStatus;
    }


    private void SetPlayerShotStatus(bool shotStatus)
    {
        _shotStatus = shotStatus;
    }
    public override void SetShellForWeapon()
    {
        _absShell = _shellPoolContainer.poolShellGun;
    }
    public override void SetTimeBetweenShot()
    {
        _timeRechargeBullet = _weaponInfo.timeRechargeBullet;
    }
    public override void SetIsCanOverheat()
    {
        _isCanOverheat = _weaponInfo.isCanOverheat;
    }
    public override void SetTimeCoolingOverheat()
    {
        _timeCoolingOverheat = _weaponInfo.timeCoolingOverheat;
    }
    public override void SetCountBulletToIverheat()
    {
        _countBulletToOverheat = _weaponInfo.countBulletToOverheat;
    }
    public override void SetTimeCoolingBulletRecharge()
    {
        _timeCoolingBulletRecharge = _weaponInfo.timeCoolingBulletRecharge;
    }
  

    public override bool CheckPersonalWeaponCondition()
    {
        return _shotStatus;
    }

    public override void SetLerpValue(float currentValue, float defaultValue, bool isRevers)
    {
        if(isRevers)
            _shotPlayer.overheatFillImage.fillAmount = 1 - (currentValue / defaultValue);
        else 
            _shotPlayer.overheatFillImage.fillAmount = (currentValue / defaultValue);
    }
}
