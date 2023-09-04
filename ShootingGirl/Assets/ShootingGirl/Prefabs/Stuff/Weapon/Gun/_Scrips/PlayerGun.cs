using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : AbsPlayerWeapon
{
    public override void SetShellForWeapon()
    {
        _absShell = _shellPoolContainer.poolShellGun;
    }
}
