using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponInfo", menuName = "Scriptable Object/Weapon Info", order = 52)]
public class WeaponInfo : ScriptableObject
{
    [SerializeField] [Min(0)] private int _damage;
    [SerializeField] [Min(0)] private float _range;
    [SerializeField] [Min(0)] private float _timeRecharge;
    [SerializeField] [Min(0)] private float _speedTrakeAim;
    [SerializeField] [Min(0)] private float _sppedOfShell;
 

    public int damage { get { return _damage; }private set { _damage = value; } }
    public float range{ get { return _range; } private set { _range = value; }}
    public float timeRecharge{ get { return _timeRecharge; } private set { _timeRecharge = value; }}
    public float speedTrakeAim{ get { return _speedTrakeAim; } private set { _speedTrakeAim = value; }}
    public float sppedOfShell { get { return _sppedOfShell; } private set { _sppedOfShell = value; } }


}
