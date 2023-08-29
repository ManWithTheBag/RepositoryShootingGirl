using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsCharacter : MonoBehaviour, IDistanceToAimsComparable, IRefreshible, ITakeDamage
{
    [SerializeField] private CharacterInfo _characterInfo;
    [SerializeField] private CommonMapInfo _commonMapInfo;

    protected float _distancePlayerToAim;
    protected Transform _thisTransform;

    private AbsCharacterMovement _absCharacterMovement;
    private ScoreController _scoreController;
    private float _currentHealth;

    public CharacterInfo CharacterInfo { get { return _characterInfo; } private set { _characterInfo = value; } }
    public CommonMapInfo CommonMapInfo { get { return _commonMapInfo; } private set { _commonMapInfo = value; } }
    public float DistancePlayerToAim { get { return _distancePlayerToAim; } private set { _distancePlayerToAim = value; } }
    public Transform SortTransform { get; private set; }

    private void OnEnable()
    {
        _currentHealth = _characterInfo.FullHealth;
    }
    private void OnDisable()
    {
        
    }

    public virtual void Awake()
    {
        _thisTransform = transform;
        SortTransform = _thisTransform;
        _absCharacterMovement = GetComponent<AbsCharacterMovement>();
        _scoreController = GameObject.Find("UIController").GetComponent<ScoreController>();
    }

    public void CalculateDistanceAimToPlayer()
    {
        _distancePlayerToAim = Vector3.Distance(_thisTransform.position, Player.s_playerTransform.position);
    }

    public void TotalRefresh()
    {
        gameObject.SetActive(false);
        GlobalEventManager.SearchNewAimEvent.Invoke();
        _scoreController.AddScore(_characterInfo.ScoreInEnemy);
        _absCharacterMovement.SetStartPosition();
        gameObject.SetActive(true);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if(_currentHealth <= 0)
        {
            TotalRefresh();
        }
    }



}
