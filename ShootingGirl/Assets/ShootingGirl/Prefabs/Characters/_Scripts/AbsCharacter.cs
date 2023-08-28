using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsCharacter : MonoBehaviour, IDistanceToAimsComparable, IRefreshible
{
    [SerializeField] private CharacterInfo _characterInfo;
    [SerializeField] private CommonMapInfo _commonMapInfo;

    private AbsCharacterMovement _absCharacterMovement;
    protected float _distancePlayerToAim;
    protected Transform _thisTransform;

    public CharacterInfo CharacterInfo { get { return _characterInfo; } private set { _characterInfo = value; } }
    public CommonMapInfo CommonMapInfo { get { return _commonMapInfo; } private set { _commonMapInfo = value; } }
    public float DistancePlayerToAim { get { return _distancePlayerToAim; } private set { _distancePlayerToAim = value; } }
    public Transform SortTransform { get; private set; }

    public virtual void Awake()
    {
        _thisTransform = transform;
        SortTransform = _thisTransform;
        _absCharacterMovement = GetComponent<AbsCharacterMovement>();
    }


    public void CalculateDistanceAimToPlayer()
    {
        _distancePlayerToAim = Vector3.Distance(_thisTransform.position, Player.s_playerTransform.position);
    }

    public void TotalRefresh()
    {
        gameObject.SetActive(false);
        GlobalEventManager.SearchNewAimEvent.Invoke();
        _absCharacterMovement.SetStartPosition();
        gameObject.SetActive(true);
    }
}
