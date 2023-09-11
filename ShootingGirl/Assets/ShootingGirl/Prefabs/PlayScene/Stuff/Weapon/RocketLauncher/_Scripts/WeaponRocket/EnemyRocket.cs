using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : AbsEnemyWeapon
{
    public override void SetPoolShellForWeapon()
    {
        _poolCurrentShell = _shellPoolContainer.poolShelRocket;
    }
}
