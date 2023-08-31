using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : AbsWeapon
{
    private PlayerButtonController _shotPlayer;

    public override void Awake()
    {
        base.Awake();
        _shotPlayer = GameObject.Find("UIController").GetComponent<PlayerButtonController>();
    }

    private void OnEnable()
    {
        _shotPlayer.ShotPlayerEvent += Shot;
    }
    private void OnDisable()
    {
        _shotPlayer.ShotPlayerEvent -= Shot;
    }

    public override void SetShellForWeapon()
    {
        _absShell = _shellPoolContainer.poolShellGun;
    }
}
