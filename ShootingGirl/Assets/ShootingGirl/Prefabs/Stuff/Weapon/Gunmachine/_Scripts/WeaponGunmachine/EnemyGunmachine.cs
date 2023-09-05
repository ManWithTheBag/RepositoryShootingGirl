using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunmachine : AbsEnemyWeapon
{
    public override void SetPoolShellForWeapon()
    {
        _poolCurrentShell = _shellPoolContainer.poolShellGunmachine;
    }
}
