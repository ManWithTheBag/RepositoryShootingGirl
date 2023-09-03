using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsWeapon : MonoBehaviour
{
    [SerializeField] protected WeaponInfo _weaponInfo;
    [SerializeField] private Transform _weaponModel;
    [SerializeField] protected Transform _bodyCharacter;
    [SerializeField] protected Transform _firePosition;

    protected ShellPoolContainer _shellPoolContainer;
    protected IPool<AbsShell> _absShell;
    protected AbsCharacter _absCharacter;
    protected Vector3 _aimDirection;


    private AbsCharacterMovement _absCharacterMovement;

    //Shot timer condition
    protected float _timeRechargeBullet;
    protected float _timeCoolingOverheat;
    protected float _timeCoolingBulletRecharge;
    protected float _countBulletToOverheat;
    protected bool _isCanOverheat;
    private float _currentTimeRechargeBullet;
    private float _currentTimeCoolingOverheat;
    protected int _currentCountBulletToOverheat;
    private float _currentTimeCoolingBulletRecharge;


    public virtual void Awake()
    {
        _shellPoolContainer = GameObject.Find("ShellCotroller").GetComponent<ShellPoolContainer>();
        _absCharacterMovement = GetComponent<AbsCharacterMovement>();
        _absCharacter = GetComponent<AbsCharacter>();
        SetShellForWeapon();
        SetTimeBetweenShot();
        SetIsCanOverheat();
        SetCountBulletToIverheat();
        SetTimeCoolingBulletRecharge();
        SetTimeCoolingOverheat();
    }

    #region Setup kind of Weapon

    public abstract void SetShellForWeapon();
    public abstract void SetTimeBetweenShot();
    public abstract void SetIsCanOverheat();
    public abstract void SetCountBulletToIverheat();
    public abstract void SetTimeCoolingBulletRecharge();
    public abstract void SetTimeCoolingOverheat();

    public abstract bool CheckPersonalWeaponCondition();
    #endregion

    #region Check Weapon Conditions like: Recharge and Overheat;

    private void Update()
    {
        ChechOverheat();
    }
    private void ChechOverheat()
    {
        if (_isCanOverheat)
        {
            if (_currentCountBulletToOverheat <= _countBulletToOverheat)
            {
                CheckShotWeaponCondition();
            }
            else
            {
                StartCoolingOverheat();
            }
        }
        else
        {
            CheckShotWeaponCondition();
        }
    }
    private void CheckShotWeaponCondition()
    {
        if (CheckTimeRechargeBullet() && CheckPersonalWeaponCondition())
        {
            Shot();

            _currentCountBulletToOverheat ++;
            SetLerpValue(_currentCountBulletToOverheat, _countBulletToOverheat, false);
        }

        if (CheckTimeCoolingBulletRecharge() && CheckPersonalWeaponCondition() == false)
        {
            if (_currentCountBulletToOverheat > 0)
            {
                _currentCountBulletToOverheat --;
                SetLerpValue(_currentCountBulletToOverheat, _countBulletToOverheat, false);
            }
        }
    }
    private void StartCoolingOverheat()
    {
        if (CheckTimeCoolingOverheat())
        {
            _currentCountBulletToOverheat = 0;
        }
        else
        {
            SetLerpValue(_currentTimeCoolingOverheat, _timeCoolingOverheat, true);
        }
    }

    #endregion

    #region Timer Region

    private bool CheckTimeRechargeBullet()
    {
        return DefaultTimer(ref _currentTimeRechargeBullet, _timeRechargeBullet);
    }

    private bool CheckTimeCoolingBulletRecharge()
    {
        return DefaultTimer(ref _currentTimeCoolingBulletRecharge, _timeCoolingBulletRecharge);
    }
    
    private bool CheckTimeCoolingOverheat()
    {
        return DefaultTimer(ref _currentTimeCoolingOverheat, _timeCoolingOverheat);
    }

    private bool DefaultTimer(ref float currentValue, float defaultValue)
    {
        if (currentValue >= defaultValue)
        {
            currentValue = 0;
            return true;
        }
        else
        {
            currentValue += Time.deltaTime;
            return false;
        }
    }
    #endregion
    public virtual void SetLerpValue(float currentValue, float defaultValue, bool isRevers) { }

    #region Take Aim Model and Weapon

    private void LateUpdate()
    {
        TakeAimVeaponModel();
        TakeAimBody();
    }
    private void TakeAimVeaponModel()
    {
        _aimDirection = (_absCharacterMovement.GetAimSootTransform().position - _weaponModel.position);
        _weaponModel.rotation = Quaternion.Lerp(_weaponModel.rotation, Quaternion.LookRotation(_aimDirection), Time.fixedDeltaTime * _weaponInfo.speedTrakeAim);
    }
    private void TakeAimBody()
    {
        _aimDirection = (_absCharacterMovement.GetAimSootTransform().position - _absCharacter.thisTransform.position);
        _bodyCharacter.rotation = Quaternion.Lerp(_bodyCharacter.rotation, Quaternion.LookRotation(_aimDirection), Time.fixedDeltaTime * _weaponInfo.speedTrakeAim);
    }

    #endregion

    protected void Shot()
    {
        //Physics.Raycast(_firePosition.position, _aimDirection, out _hit, Mathf.Infinity);
        //_hit.transform.TryGetComponent(out ITakeDamage iTakeDamage);

        AbsShell shell = _absShell.GetElement();
        shell._thisTransform.position = _firePosition.position;
        shell._thisTransform.rotation = _firePosition.rotation;
        shell.SetShellData(_weaponInfo.damage, _absCharacter.thisTransform);
        shell.SetupShell(_aimDirection, _weaponInfo.sppedOfShell);
        shell.SetVisibleStatusGO(true);
    }

}
