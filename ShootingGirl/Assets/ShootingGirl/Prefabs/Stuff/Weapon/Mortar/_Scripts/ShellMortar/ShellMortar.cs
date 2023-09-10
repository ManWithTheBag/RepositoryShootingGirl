using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellMortar : AbsShell
{
    private ShellMortarMovement _shellMortarMovement;
    private SphereCollider _sphereCollider;

    private float _radiusExplosion;

    public ShellMortarMovement shellMortarMovement { get; private set; }

    public override void Awake()
    {
        _thisTransform = transform;
        _shellMortarMovement = GetComponent<ShellMortarMovement>();
        _sphereCollider = GetComponent<SphereCollider>();
    }


    public override void FixedUpdate(){}

    public override void SetPositions(Transform startPosition, Transform finishPosition)
    {
        _shellMortarMovement.SetPositions(startPosition, finishPosition);
    }

    public override void SetPropertyToFlight(float timeToFlight, float maxHeight, float radiusExplosion)
    {
        _shellMortarMovement.SetPropertyToFlight(timeToFlight, maxHeight);
        _radiusExplosion = radiusExplosion;
    }

    public void ShellMortarExplosion()
    {
        _sphereCollider.enabled = true;
        _sphereCollider.radius = _radiusExplosion;

        StartCoroutine(TimerExplosion());
    }


    private IEnumerator TimerExplosion()
    {
        yield return new WaitForSeconds(1);
        ShellMortarRefresh();
    }


    private void ShellMortarRefresh()
    {
        _sphereCollider.enabled = false;
        _sphereCollider.radius = 0;
        _thisTransform.position = Vector3.zero;
        SetVisibleStatusGO(false);
    }

    public override void TotalRefresh()
    {
    }
    public override void CheckDestroyDistance()
    {
    }
}
