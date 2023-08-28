using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VeaponInfo", menuName = "Scriptable Object/Veapon Info", order = 52)]
public class VeaponInfo : ScriptableObject
{
    [SerializeField] [Min(0)] private float _damage;
    [SerializeField] [Min(0)] private float _range;
    [SerializeField] [Min(0)] private float _timeRecharge;
    [SerializeField] [Min(0)] private float _speedTrakeAim;
 

    public float Damage
    {
        get { return _damage; }
        private set { _damage = value; }
    }
    public float Range
    {
        get { return _range; }
        private set { _range = value; }
    }
    public float TimeRecharge
    {
        get { return _timeRecharge; }
        private set { _timeRecharge = value; }
    }
    public float SpeedTrakeAim
    {
        get { return _speedTrakeAim; }
        private set { _speedTrakeAim = value; }
    }

}
