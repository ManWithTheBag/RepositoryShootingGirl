using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsWeapon : MonoBehaviour
{
    [SerializeField] private WeaponInfo _weaponInfo;
    [SerializeField] private Transform _weaponModel;
    [SerializeField] private Transform _fireTransform;

    private AbsCharacterMovement _absCharacterMovement;
    private Vector3 _aimDirection;
    RaycastHit _hit;

    public virtual void Awake()
    {
        _absCharacterMovement = GetComponent<AbsCharacterMovement>();
    }

    private void Update()
    {
        TakeAimVeaponModel();
    }

    private void TakeAimVeaponModel()
    {
        _aimDirection = (_absCharacterMovement.AimTransform.position - _weaponModel.position);
        _weaponModel.rotation = Quaternion.Lerp(_weaponModel.rotation, Quaternion.LookRotation(_aimDirection), Time.deltaTime * _weaponInfo.SpeedTrakeAim);

    }


    protected void Shot()
    {
        bool result = Physics.Raycast(_fireTransform.position, _aimDirection, out _hit, Mathf.Infinity);

        if (result)
        {
            if(_hit.transform.TryGetComponent(out ITakeDamage iTakeDamage))
            {
                iTakeDamage.TakeDamage(_weaponInfo.Damage);
            }
        }
    }
}
