using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunmachine : AbsPlayerWeapon
{
    public override void SetPoolShellForWeapon()
    {
        _poolCurrentShell = _shellPoolContainer.poolShellGunmachine;
    }
}
