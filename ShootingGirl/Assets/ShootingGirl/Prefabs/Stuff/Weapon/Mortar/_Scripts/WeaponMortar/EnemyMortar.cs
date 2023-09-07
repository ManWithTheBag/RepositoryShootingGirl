using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMortar : AbsEnemyWeapon
{
    [SerializeField]private ShellMortar _shellMortar;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _timeToFlight;
    [SerializeField]private Transform _aimTransform;
    private Transform _thisTransform;

    public override void SetPoolShellForWeapon()
    {
        _poolCurrentShell = _shellPoolContainer.poolShellMortar;
    }

    public override bool CheckPersonalWeaponCondition()
    {
        if (Vector3.Distance(_thisTransform.position, _aimShotTransform.position) < _weaponInfo.range)
            return true;

        return false;
    }

    public override void SetShellData(AbsShell shell)
    {
        shell.SetShellData(_weaponInfo.damage, _absCharacter.thisTransform);
        shell.SetPropertyToFlight(_weaponInfo.mortarTimeToFlight, weaponInfo.mortarMaxHeight);
        shell.SetPositions(_firePosition, _aimShotTransform);

    }
}
