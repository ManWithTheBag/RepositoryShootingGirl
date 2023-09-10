using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellMortarMovement : MonoBehaviour
{
    private ShellMortar _shellMortar;
    private Transform _thisTransform;
    private Transform _mortarTransform;
    private Transform _aimTransform;
    private float _maxHeight;
    private float _timeToFlight;
    private Vector3 _positionStart_1;
    private Vector3 _positionStart_2;
    private Vector3 _positionFinish_1;
    private Vector3 _positionFinish_2;

    private void Awake()
    {
        _thisTransform = transform;
        _shellMortar = GetComponent<ShellMortar>();
    }

    public void SetPropertyToFlight(float timeToFlight, float maxHeight)
    {
        _timeToFlight = timeToFlight;
        _maxHeight = maxHeight;
    }
    public void SetPositions(Transform startPosition, Transform finishPosition)
    {
        _mortarTransform = startPosition;
        _aimTransform = finishPosition;

        SetupTrajectory();

        StartCoroutine(MoveShellMortar());
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


    private IEnumerator MoveShellMortar()
    {
        for (float i = 0; i < 1; i += Time.deltaTime / _timeToFlight)
        {
            if (_shellMortar.isAutoTakeAim)
                SetupTrajectory();

            _thisTransform.position = Bezier.GetPoint(_positionStart_1, _positionStart_2, _positionFinish_1, _positionFinish_2, i);
            _thisTransform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(_positionStart_1, _positionStart_2, _positionFinish_1, _positionFinish_2, i));

            yield return null;
        }

        _shellMortar.ShellMortarExplosion();
    }

    private void OnDrawGizmos()
    {

        int sigmentsNumber = 20;
        Vector3 preveousePoint = _positionStart_1;

        for (int i = 0; i < sigmentsNumber + 1; i++)
        {
            float paremeter = (float)i / sigmentsNumber;
            Vector3 point = Bezier.GetPoint(_positionStart_1, _positionStart_2, _positionFinish_1, _positionFinish_2, paremeter);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }

    }
}
