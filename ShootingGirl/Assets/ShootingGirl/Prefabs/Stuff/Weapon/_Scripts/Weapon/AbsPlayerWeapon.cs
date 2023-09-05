using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsPlayerWeapon : AbsWeapon
{
    private AimsPoolContainer _aimsPoolContainer;
    protected PlayerButtonController _playerButtonController;
    private bool _playerShotStatus;
    private Transform _nearestAimOfPlayer;

    public override void Awake()
    {
        base.Awake();
       
        _playerButtonController = GameObject.Find("UIController").GetComponent<PlayerButtonController>();
        _aimsPoolContainer = GameObject.Find("CaractersController").GetComponent<AimsPoolContainer>();
    }

    public virtual void OnEnable()
    {
        _playerButtonController.shotButton.ShotButtonStatusEvent += SetPlayerShotStatus;
        _aimsPoolContainer.FoundNearestAimOfPlayerEvent += SetNearestAimOfPlayer;
    }
    public virtual void OnDisable()
    {
        _playerButtonController.shotButton.ShotButtonStatusEvent -= SetPlayerShotStatus;
        _aimsPoolContainer.FoundNearestAimOfPlayerEvent -= SetNearestAimOfPlayer;
    }

    private void SetPlayerShotStatus(bool shotStatus)
    {
        _playerShotStatus = shotStatus;
    }
    public override bool CheckPersonalWeaponCondition()
    {
        return _playerShotStatus;
    }

    public override void SetAbsCharacter()
    {
        transform.parent.TryGetComponent<AbsCharacter>(out AbsCharacter absCharacter); _absCharacter = absCharacter;
    }
    private void SetNearestAimOfPlayer(Transform nearestAimOfPlayer)
    {
        _nearestAimOfPlayer = nearestAimOfPlayer;
        SetAimSootTransform();
    }
    public override void SetAimSootTransform()
    {
        _aimShotTransform = _nearestAimOfPlayer;
    }

    public override void SetLerpValue(float currentValue, float defaultValue, bool isRevers)
    {
        if (_weaponInfo.isCanOverheat)
        {
            if (isRevers)
                _playerButtonController.overheatFillImage.fillAmount = 1 - (currentValue / defaultValue);
            else
                _playerButtonController.overheatFillImage.fillAmount = (currentValue / defaultValue);
        }
    }
}
