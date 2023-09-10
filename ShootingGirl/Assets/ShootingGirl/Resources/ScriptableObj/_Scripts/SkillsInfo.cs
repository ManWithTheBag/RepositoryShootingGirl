using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillsInfo", menuName = "Scriptable Object/Skills Info", order = 52)]
public class SkillsInfo : ScriptableObject
{
    [SerializeField] [Min(0)] private int _price;
    [SerializeField] [Min(0)] private int _damage;
    [SerializeField] [Min(0)] private float _timeToFlight;
    [SerializeField] [Min(0)] private float _maxHeight;
    [SerializeField] [Min(0)] private float _radiusExplosion;

    public int price { get { return _price; } private set { _price = value; } }
    public int damage { get { return _damage; } private set { _damage = value; } }
    public float timeToFlight { get { return _timeToFlight; } private set { _timeToFlight = value; } }
    public float maxHeight { get { return _maxHeight; } private set { _maxHeight = value; } }
    public float radiusExplosion { get { return _radiusExplosion; } private set { _radiusExplosion = value; } }


}
