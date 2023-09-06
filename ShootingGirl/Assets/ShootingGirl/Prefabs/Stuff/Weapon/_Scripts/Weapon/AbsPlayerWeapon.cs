using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsPlayerWeapon : AbsWeapon
{
    private AimsPoolContainer _aimsPoolContainer;
    protected PlayerButtonController _playerButtonController;
    private bool _playerShotStatus;
    private Transform _thisTransform;

    private RaycastHit _hit;
    private Ray _ray;

    public override void Awake()
    {
        base.Awake();

        _thisTransform = transform;
        _playerButtonController = GameObject.Find("UIController").GetComponent<PlayerButtonController>();
        _aimsPoolContainer = GameObject.Find("CaractersController").GetComponent<AimsPoolContainer>();
    }

    public virtual void OnEnable()
    {
        _playerButtonController.shotButton.ShotButtonStatusEvent += SetPlayerShotStatus;
    }
    public virtual void OnDisable()
    {
        _playerButtonController.shotButton.ShotButtonStatusEvent -= SetPlayerShotStatus;
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

    private void Start()
    {
        _aimShotTransform = _aimsPoolContainer.GetNearestAimForPlayer();
        GlobalEventManager.GetNewAimForPlayerEvent?.Invoke(_aimShotTransform);
    }

    public override void Update()
    {
        SearchNewAim();

        base.Update();
    }

    private void SearchNewAim()
    {
        _ray = new Ray(_thisTransform.position, Vector3.forward);

        if(Physics.Raycast(_ray, out _hit, Mathf.Infinity))
        {
            SetAimSootTransform();
        }
    }

    public override void SetAimSootTransform()
    {
        _aimShotTransform = _hit.transform;
        GlobalEventManager.GetNewAimForPlayerEvent?.Invoke(_aimShotTransform);
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
