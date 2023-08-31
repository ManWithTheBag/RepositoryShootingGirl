using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsWeapon : MonoBehaviour
{
    [SerializeField] private WeaponInfo _weaponInfo;
    [SerializeField] private Transform _weaponModel;
    [SerializeField] protected Transform _bodyCharacter;
    [SerializeField] private Transform _firePosition;

    protected ShellPoolContainer _shellPoolContainer;
    protected IPool<AbsShell> _absShell;

    private AbsCharacterMovement _absCharacterMovement;
    private AbsCharacter _absCharacter;
    private Vector3 _aimDirection;

    RaycastHit _hit;

    public virtual void Awake()
    {
        _shellPoolContainer = GameObject.Find("ShellCotroller").GetComponent<ShellPoolContainer>();
        _absCharacterMovement = GetComponent<AbsCharacterMovement>();
        _absCharacter = GetComponent<AbsCharacter>();
        SetShellForWeapon();
    }

    public abstract void SetShellForWeapon();

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
