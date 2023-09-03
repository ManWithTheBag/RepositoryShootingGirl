using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponInfo", menuName = "Scriptable Object/Weapon Info", order = 52)]
public class WeaponInfo : ScriptableObject
{
    [Header("Weapon data")]
    [SerializeField] [Min(0)] private int _damage;
    [SerializeField] [Min(0)] private float _range;
    [SerializeField] [Min(0)] private float _timeRechargeBullet;

    [Header("Other")]
    [SerializeField] [Min(0)] private float _speedTrakeAim;
    [SerializeField] [Min(0)] private float _sppedOfShell;

    [Header("Weapon Overheat")]
    [SerializeField] private bool _isCanOverheat;
    [SerializeField] [Min(0)] private float _timeCoolingBulletRecharge; 
    [SerializeField] [Min(0)] private float _countBulletToOverheat;
    [SerializeField] [Min(0)] private float _timeCoolingOverheat;

    public int damage { get { return _damage; }private set { _damage = value; } }
    public float range{ get { return _range; } private set { _range = value; }}

    public float timeRechargeBullet { get { return _timeRechargeBullet; } private set { _timeRechargeBullet = value; } }
    public float speedTrakeAim{ get { return _speedTrakeAim; } private set { _speedTrakeAim = value; }}
    public float sppedOfShell { get { return _sppedOfShell; } private set { _sppedOfShell = value; } }

    public bool isCanOverheat { get { return _isCanOverheat; } private set { _isCanOverheat = value; } }
    public float countBulletToOverheat { get { return _countBulletToOverheat; } private set { _countBulletToOverheat = value; } }
    public float timeCoolingOverheat { get { return _timeCoolingOverheat; } private set { _timeCoolingOverheat = value; }}
    public float timeCoolingBulletRecharge { get { return _timeCoolingBulletRecharge; } private set { _timeCoolingBulletRecharge = value; } }


}
