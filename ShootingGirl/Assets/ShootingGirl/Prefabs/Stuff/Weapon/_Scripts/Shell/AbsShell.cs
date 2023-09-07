using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class AbsShell : MonoBehaviour, IRefreshible, IVisibleInvisible, IDamaging
{
    [SerializeField] private CommonGameInfo _commonGameInfo;
    [NonSerialized]public Transform _thisTransform;
    private AbsShellMovement _absShellMovement;
    private Rigidbody _thisRB;

    private int _damage;
    private Transform _shootsCharacter;

    public AbsShellMovement absShellMovement { get { return _absShellMovement; } private set { _absShellMovement = value; } }
    public int damage{get { return _damage; }private set { _damage = value; }}
    public Transform shootsCharacter { get { return _shootsCharacter; }private set { _shootsCharacter = value; }}

    public virtual void Awake()
    {
        _thisTransform = transform;
        _absShellMovement = GetComponent<AbsShellMovement>();
        _thisRB = GetComponent<Rigidbody>();
    }

    public virtual void FixedUpdate()
    {
        CheckDestroyDistance();
    }

    public void SetShellData(int damage, Transform shootsCharacter)
    {
        _damage = damage;
        _shootsCharacter = shootsCharacter;
    }

    public void SetupShell(Vector3 derectionMove, float speedOfShell)
    {
        _absShellMovement.SetDirectionMove(derectionMove);
        _absShellMovement.SetSpeedOfShell(speedOfShell);
    }

    public virtual void SetPropertyToFlight(float timeToFlight, float maxHeight) {}
    public virtual void SetPositions(Transform startPosition, Transform finishPosition) { }

    public virtual void TotalRefresh()
    {
        SetVisibleStatusGO(false);
        _thisRB.velocity = Vector3.zero;
        _thisRB.angularVelocity = Vector3.zero;
    }

    public void SetVisibleStatusGO(bool isStatus)
    {
        gameObject.SetActive(isStatus);
    }

    private void CheckDestroyDistance()
    {
        if(Vector3.Distance(_thisTransform.position, _shootsCharacter.position) > _commonGameInfo.destroyDistanceShell)
        {
            TotalRefresh();
        }
    }

}
