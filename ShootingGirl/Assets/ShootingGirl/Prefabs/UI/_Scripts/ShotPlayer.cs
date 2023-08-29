using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotPlayer : MonoBehaviour
{
    [SerializeField] private Button _shotButton;

    public event Action ShotPlayerEvent;

    private void OnEnable()
    {
        _shotButton.onClick.AddListener(ActivateShotButton);
    }
    private void OnDisable()
    {
        _shotButton.onClick.RemoveListener(ActivateShotButton);
    }

    private void ActivateShotButton()
    {
        ShotPlayerEvent?.Invoke();
    }
}
