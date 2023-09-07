using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellMortar : AbsShell
{
    private ShellMortarMovement _shellMortarMovement;


    public override void Awake()
    {
        _thisTransform = transform;
        _shellMortarMovement = GetComponent<ShellMortarMovement>();
    }


    public override void FixedUpdate(){}

    public override void SetPositions(Transform startPosition, Transform finishPosition)
    {
        _shellMortarMovement.SetPositions(startPosition, finishPosition);
    }

    public override void SetPropertyToFlight(float timeToFlight, float maxHeight)
    {
        _shellMortarMovement.SetPropertyToFlight(timeToFlight, maxHeight);
    }

    public override void TotalRefresh()
    {
        SetVisibleStatusGO(false);
    }
}
