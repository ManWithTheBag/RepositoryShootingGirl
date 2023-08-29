using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform _cameraPlayerPosition;
    private Transform _thisTransform;

    private void Awake()
    {
        _thisTransform = transform;
    }

    private void Start()
    {
        _cameraPlayerPosition = GameObject.Find("CameraPlayerPosition").transform;
        
    }

    private void Update()
    {
        _thisTransform.position = _cameraPlayerPosition.position;
    }
}
