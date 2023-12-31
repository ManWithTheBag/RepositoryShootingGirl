using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsPlayerBaseModetState : MonoBehaviour
{
    [SerializeField] private CharacterInfo _characterInfo;
    private float _currentHealthThisModel;

    private GameObject _thisGO;
    private Player _player;
    private bool _isDied;

    public CharacterInfo characterInfo { get { return _characterInfo; } private set { _characterInfo = value; } }
    public float currentHealthThisModel { get { return _currentHealthThisModel; } private set { _currentHealthThisModel = value; } }
    public GameObject thisGO { get { return _thisGO; } private set { _thisGO = value; } }
    public bool isDied { get { return _isDied; }  set { _isDied = value; } }


    private void Awake()
    {
        transform.parent.TryGetComponent<Player>(out Player player); _player = player;
        _currentHealthThisModel = _characterInfo.fullHealth;
    }

    private void Start()
    {
        _thisGO = gameObject;
    }


    public virtual void Enter()
    {
        if(_player != null)
            _player.SetCurrentCharacterInfo(_characterInfo);

        Debug.Log("Selected: " + _characterInfo.typePlayerModel);

        SetModelStatus(true);
    }

    public virtual void Exit()
    {
        SetModelStatus(false);
    }

    private void SetModelStatus(bool status)
    {
        gameObject.SetActive(status);
    }

    public void SetCurrentHealthForThisModel(float currentHealthThisModel)
    {
        _currentHealthThisModel = currentHealthThisModel;
    }

    public void DiedPlayerModel()
    {
        _isDied = true;
        SetModelStatus(false);
    }
}
