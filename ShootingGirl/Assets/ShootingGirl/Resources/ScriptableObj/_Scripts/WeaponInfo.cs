using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponInfo", menuName = "Scriptable Object/Weapon Info", order = 52)]
public class WeaponInfo : ScriptableObject
{
    [Header("Weapon data")]
    [SerializeField] [Min(0)] private int _damage;
    [SerializeField] [Min(0)] private float _range;
    [SerializeField] [Min(0)] private float _timeRechargeShell;

    [Header("Other")]
    [SerializeField] [Min(0)] private float _speedTrakeAim;
    [SerializeField] [Min(0)] private float _sppedOfShell;
    [SerializeField] [Min(0)] private float _mortarTimeToFlight;
    [SerializeField] [Min(0)] private float _mortarMaxHeight;

    [Header("Weapon Overheat")]
    [SerializeField] private bool _isCanOverheat;
    [SerializeField] [Min(0)] private float _timeCoolingShellRecharge; 
    [SerializeField] [Min(0)] private float _countShellToOverheat;
    [SerializeField] [Min(0)] private float _timeCoolingOverheat;

    public int damage { get { return _damage; }private set { _damage = value; } }
    public float range{ get { return _range; } private set { _range = value; }}
    public float timeRechargeShell { get { return _timeRechargeShell; } private set { _timeRechargeShell = value; } }

    public float speedTrakeAim{ get { return _speedTrakeAim; } private set { _speedTrakeAim = value; }}
    public float sppedOfShell { get { return _sppedOfShell; } private set { _sppedOfShell = value; } }
    public float mortarTimeToFlight { get { return _mortarTimeToFlight; } private set { _mortarTimeToFlight = value; } }
    public float mortarMaxHeight { get { return _mortarMaxHeight; } private set { _mortarMaxHeight = value; } }


    public bool isCanOverheat { get { return _isCanOverheat; } private set { _isCanOverheat = value; } }
    public float countShellToOverheat { get { return _countShellToOverheat; } private set { _countShellToOverheat = value; } }
    public float timeCoolingOverheat { get { return _timeCoolingOverheat; } private set { _timeCoolingOverheat = value; }}
    public float timeCoolingShellRecharge { get { return _timeCoolingShellRecharge; } private set { _timeCoolingShellRecharge = value; } }


}
