using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameInfo", menuName = "Scriptable Object/Game Info", order = 52)]
public class GameInfo :ScriptableObject
{
    [SerializeField][Min(0)] private float _destroyDistanceShell;
    [SerializeField][Min(0)] private float _timeLerpingValue;

    public float destroyDistanceShell { get { return _destroyDistanceShell; } set { _destroyDistanceShell = value; }}
    public float timeLerpingValue { get { return _timeLerpingValue; } private set { _timeLerpingValue = value; } }


}
