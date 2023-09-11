using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : AbsEnemyWeapon
{
    public override void SetPoolShellForWeapon()
    {
        _poolCurrentShell = _shellPoolContainer.poolShellGun;
    }

}
