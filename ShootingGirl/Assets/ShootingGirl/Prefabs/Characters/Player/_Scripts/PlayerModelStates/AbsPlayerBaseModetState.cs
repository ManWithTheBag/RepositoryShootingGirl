using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsPlayerBaseModetState : MonoBehaviour
{
    [SerializeField] private CharacterInfo _characterInfo;
    private float _currentHealthThisModel;

    private GameObject _thisGO;
    private Player _player;

    public CharacterInfo characterInfo { get { return _characterInfo; } private set { _characterInfo = value; } }
    public float currentHealthThisModel { get { return _currentHealthThisModel; } private set { _currentHealthThisModel = value; } }


    private void Awake()
    {
        _thisGO = gameObject;
        transform.parent.TryGetComponent<Player>(out Player player); _player = player;
        _currentHealthThisModel = _characterInfo.fullHealth;
        _thisGO.SetActive(false);
    }

    public virtual void Enter()
    {
        _player.SetCurrentCharacterInfo(_characterInfo);
        _thisGO.SetActive(true);
    }

    public virtual void Exit()
    {
        _thisGO.SetActive(false);
    }

    public void SetCurrentHealthForThisModel(float currentHealthThisModel)
    {
        _currentHealthThisModel = currentHealthThisModel;
    }
}
