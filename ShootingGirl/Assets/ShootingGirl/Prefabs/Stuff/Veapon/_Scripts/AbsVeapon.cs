using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsVeapon : MonoBehaviour
{
    [SerializeField] private VeaponInfo _veaponInfo;
    [SerializeField] private Transform _veaponModel;
    [SerializeField] private Transform _fireTransform;

    private AbsCharacterMovement _absCharacterMovement;
    private Vector3 _aimDirection;
    RaycastHit _hit;

    private void Awake()
    {
        _absCharacterMovement = GetComponent<AbsCharacterMovement>();
    }

    private void Update()
    {
        CheckShotButton();
        TakeAimVeaponModel();
    }

    //TODO Chenge on the UI button
    private void CheckShotButton()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Shot();
        }
    }

    private void TakeAimVeaponModel()
    {
        _aimDirection = (_absCharacterMovement.AimTransform.position - _veaponModel.position);
        _veaponModel.rotation = Quaternion.Lerp(_veaponModel.rotation, Quaternion.LookRotation(_aimDirection), Time.deltaTime * _veaponInfo.SpeedTrakeAim);

    }


    private void Shot()
    {
        bool result = Physics.Raycast(_fireTransform.position, _aimDirection, out _hit, Mathf.Infinity);

        if (result)
        {
            if(_hit.transform.TryGetComponent(out AbsCharacter absCharacter))
            {
                absCharacter.TotalRefresh();
            }
        }
    }
}
