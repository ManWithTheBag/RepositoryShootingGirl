using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="CharacterInfo", menuName = "Scriptable Object/Character Info", order = 52)]
public class CharacterInfo : ScriptableObject
{
    [SerializeField] [Min(0)] private int _fullHealth;
    [SerializeField] [Min(0)] private float _speedMove;
    [SerializeField] [Min(0)] private float _speedJump;
    [SerializeField] [Min(0)] private float _heightJump;
    [SerializeField] [Min(0)] private float _defaultY;
    [SerializeField] [Min(0)] private int _scoreInEnemy;
    [SerializeField] private Sprite _iconOfCharacter;


    
    public int fullHealth { get { return _fullHealth; } private set { _fullHealth = value; }}
    public float speedMove { get { return _speedMove; } private set { _speedMove = value; }}
    public float speedJump { get { return _speedJump; } private set { _speedJump = value; }}
    public float heightJump { get { return _heightJump; }private set { _heightJump = value; }}
    public float defaultY {get { return _defaultY; } private set { _defaultY = value; }}
    public int scoreInEnemy { get { return _scoreInEnemy; } private set { _scoreInEnemy = value; }}
    public Sprite iconOfCharacter { get { return _iconOfCharacter; } private set { _iconOfCharacter = value; }}


}
