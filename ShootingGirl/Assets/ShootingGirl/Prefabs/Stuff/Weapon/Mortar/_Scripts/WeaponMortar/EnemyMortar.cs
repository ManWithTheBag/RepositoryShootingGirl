using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMortar : AbsEnemyWeapon
{
    private Transform _thisTransform;

    public override void Awake()
    {
        base.Awake();
        _thisTransform = transform;
    }

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
        shell.SetPropertyToFlight(_weaponInfo.mortarTimeToFlight, weaponInfo.mortarMaxHeight, _weaponInfo.mortarRadiusExplosion);
        shell.SetPositions(_firePosition, _aimShotTransform);
        shell.SetAutoTakeAim(false);
    }
}
