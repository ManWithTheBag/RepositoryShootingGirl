using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsCharacter : MonoBehaviour, IDistanceToAimsComparable, IRefreshible, IVisibleInvisible
{
    [SerializeField] private CommonMapInfo _commonMapInfo;
    
    protected CharacterInfo _currentCharacterInfo;
    protected float _distancePlayerToAim;
    protected Transform _thisTransform;

    private AbsCharacterMovement _absCharacterMovement;

    public CharacterInfo currentCharacterInfo { get { return _currentCharacterInfo; } private set { _currentCharacterInfo = value; } }
    public CommonMapInfo commonMapInfo { get { return _commonMapInfo; } private set { _commonMapInfo = value; } }
    public float distancePlayerToAim { get { return _distancePlayerToAim; } private set { _distancePlayerToAim = value; } }
    public Transform thisTransform { get { return _thisTransform; } private set { _thisTransform = value; } }

    public virtual void Awake()
    {
        _thisTransform = transform;
        _absCharacterMovement = GetComponent<AbsCharacterMovement>();
    }

    public void CalculateDistanceAimToPlayer()
    {
        _distancePlayerToAim = Vector3.Distance(_thisTransform.position, Player.s_playerTransform.position);
    }

    public void TotalRefresh()
    {
        SetVisibleStatusGO(false);
        GlobalEventManager.SearchNewAimEvent.Invoke();
        _absCharacterMovement.SetStartPosition();
        //TODO Comment for not spawn new enemys
        SetVisibleStatusGO(true);
    }
    public void SetVisibleStatusGO(bool isStatus)
    {
        gameObject.SetActive(isStatus);
    }
}
