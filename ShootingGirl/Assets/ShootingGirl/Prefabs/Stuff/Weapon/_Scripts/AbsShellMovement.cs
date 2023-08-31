using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsShellMovement : MonoBehaviour
{
    private Transform _thisTransform;
    private Rigidbody _thsRB;
    private Vector3 _derection;
    private float _speedOfShell;

    private void Awake()
    {
        _thisTransform = transform;
        _thsRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _thsRB.velocity = _derection.normalized * _speedOfShell;
    }

    public void SetDirectionMove(Vector3 direction)
    {
        _derection = direction;
    }

    public void SetSpeedOfShell(float speedOfShell)
    {
        _speedOfShell = speedOfShell;
    }

}
