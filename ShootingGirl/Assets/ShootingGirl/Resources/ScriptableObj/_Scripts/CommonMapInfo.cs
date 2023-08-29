using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CommonMapInfo", menuName = "Scriptable Object/Common Map Info", order = 52)]
public class CommonMapInfo : ScriptableObject
{
    [SerializeField] private float _angleMapLimit;
    [SerializeField] private float _mapRadius;


    public float MapRadius { get { return _mapRadius; } private set { _mapRadius = value; }}
    public float AngleMapLimit { get { return _angleMapLimit; } private set { _angleMapLimit = value; }}

}
