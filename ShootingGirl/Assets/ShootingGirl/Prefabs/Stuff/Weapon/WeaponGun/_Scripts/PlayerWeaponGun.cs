using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponGun : AbsWeapon
{
    private ShotPlayer _shotPlayer;

    public override void Awake()
    {
        base.Awake();
        _shotPlayer = GameObject.Find("UIController").GetComponent<ShotPlayer>();
    }

    private void OnEnable()
    {
        _shotPlayer.ShotPlayerEvent += Shot;
    }
    private void OnDisable()
    {
        _shotPlayer.ShotPlayerEvent -= Shot;
    }
}
