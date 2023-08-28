using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CharacterInfo", menuName = "Scriptable Object/Character Info", order = 52)]
public class CharacterInfo : ScriptableObject
{
    [SerializeField] [Min(0)] private float _speedMove;
    [SerializeField] [Min(0)] private float _speedTakeAim;
    [SerializeField] [Min(0)] private float _speedJump;
    [SerializeField] [Min(0)] private float _heightJump;
    [SerializeField] [Min(0)] private float _defaultY;


    
    public float SpeedMove
    {
        get { return _speedMove; }
        private set { _speedMove = value; }
    }
    public float SpeedTakeAim
    {
        get { return _speedTakeAim; }
        private set { _speedTakeAim = value; }
    }
    public float SpeedJump
    {
        get { return _speedJump; }
        private set { _speedJump = value; }
    }
    public float HeightJump
    {
        get { return _heightJump; }
        private set { _heightJump = value; }
    }
    public float DefaultY
    {
        get { return _defaultY; }
        private set { _defaultY = value; }
    }

}
