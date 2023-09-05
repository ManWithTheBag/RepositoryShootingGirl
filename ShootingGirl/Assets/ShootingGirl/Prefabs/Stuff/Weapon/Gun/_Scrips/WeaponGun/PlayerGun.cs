using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : AbsPlayerWeapon
{
    public override void SetPoolShellForWeapon()
    {
        _poolCurrentShell = _shellPoolContainer.poolShellGun;
    }
}
