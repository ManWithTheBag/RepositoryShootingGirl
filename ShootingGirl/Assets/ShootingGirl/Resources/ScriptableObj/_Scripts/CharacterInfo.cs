using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="CharacterInfo", menuName = "Scriptable Object/Character Info", order = 52)]
public class CharacterInfo : ScriptableObject
{
    [Header("Deault data")]
    [SerializeField] private string _nameOfCharacter;
    [SerializeField] private PlayerModelEnum _typePlayerModel;
    [SerializeField] private GameObject _prefabOfCharacter;
    [SerializeField] [Min(0)] private int _fullHealth;
    [SerializeField] [Min(0)] private float _defaultY;
    [SerializeField] [Min(0)] private int _scoreInEnemy;
    [SerializeField] private Sprite _iconOfCharacter;

    [Header("Movement data")]
    [SerializeField] [Min(0)] private float _speedMove;
    [SerializeField] [Min(0)] private float _speedJump;
    [SerializeField] [Min(0)] private float _heightJump;




    public string nameOfCharacter { get { return _nameOfCharacter; } private set { _nameOfCharacter = value; }}
    public PlayerModelEnum typePlayerModel { get { return _typePlayerModel; } private set { _typePlayerModel = value; } }
    public GameObject prefabOfCharacter { get { return _prefabOfCharacter; } private set { _prefabOfCharacter = value; } }
    public int fullHealth { get { return _fullHealth; } private set { _fullHealth = value; }}
    public float defaultY {get { return _defaultY; } private set { _defaultY = value; }}
    public int scoreInEnemy { get { return _scoreInEnemy; } private set { _scoreInEnemy = value; }}
    public Sprite iconOfCharacter { get { return _iconOfCharacter; } private set { _iconOfCharacter = value; }}
    public float speedMove { get { return _speedMove; } private set { _speedMove = value; }}
    public float speedJump { get { return _speedJump; } private set { _speedJump = value; }}
    public float heightJump { get { return _heightJump; }private set { _heightJump = value; }}


}
