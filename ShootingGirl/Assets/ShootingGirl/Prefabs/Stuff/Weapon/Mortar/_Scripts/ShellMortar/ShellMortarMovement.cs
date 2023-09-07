using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellMortarMovement : MonoBehaviour
{
    private Transform _mortarTransform;
    private Transform _aimTransform;
    private float _maxHeight;
    private float _timeToFlight;
    private Vector3 _positionStart_1;
    private Vector3 _positionStart_2;
    private Vector3 _positionFinish_1;
    private Vector3 _positionFinish_2;

    float _timeElapsed;
    float _valueToLerp;

    public void SetPositions(Transform startPosition, Transform finishPosition)
    {
        _mortarTransform = startPosition;
        _aimTransform = finishPosition;
    }

    public void SetPropertyToFlight(float timeToFlight, float maxHeight)
    {
        _timeToFlight = timeToFlight;
        _maxHeight = maxHeight;
    }


    void Update()
    {
        SetupTrajectory();
        GetLerpT();

        transform.position = Bezier.GetPoint(_positionStart_1, _positionStart_2, _positionFinish_1, _positionFinish_2, _valueToLerp);
        transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(_positionStart_1, _positionStart_2, _positionFinish_1, _positionFinish_2, _valueToLerp));

        CheckFinidhShell();
    }

    private void GetLerpT()
    {
        if (_timeElapsed < _timeToFlight)
        {
            _valueToLerp = Mathf.Lerp(0, 1, _timeElapsed / _timeToFlight);
            _timeElapsed += Time.deltaTime;
        }
    }

    private void SetupTrajectory()
    {
        _positionStart_1 = _mortarTransform.position;
        _positionStart_2 = _mortarTransform.position;
        _positionStart_2.y += _maxHeight;

        _positionFinish_1 = _aimTransform.position;
        _positionFinish_2 = _aimTransform.position;
        _positionFinish_2.y = 0;
    }


    private void CheckFinidhShell()
    {
        if (_valueToLerp == 1)
        {
            new GameObject("Explosion");
        }
    }

    //private void OnDrawGizmos()
    //{

    //    int sigmentsNumber = 20;
    //    Vector3 preveousePoint = _positionStart_1;

    //    for (int i = 0; i < sigmentsNumber + 1; i++)
    //    {
    //        float paremeter = (float)i / sigmentsNumber;
    //        Vector3 point = Bezier.GetPoint(_positionStart_1, _positionStart_2, _positionFinish_1, _positionFinish_2, paremeter);
    //        Gizmos.DrawLine(preveousePoint, point);
    //        preveousePoint = point;
    //    }

    //}
}
