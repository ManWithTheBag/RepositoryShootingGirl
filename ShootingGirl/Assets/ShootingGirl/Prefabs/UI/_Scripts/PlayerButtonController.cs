using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerButtonController : MonoBehaviour
{
    [SerializeField] private Button _shotButton;
    [SerializeField] private Button _refreshAimButton;

    public event Action ShotPlayerEvent;

    private void OnEnable()
    {
        _shotButton.onClick.AddListener(ActivateShotButton);
        _refreshAimButton.onClick.AddListener(ActivateRefreshAimButton);
    }
    private void OnDisable()
    {
        _shotButton.onClick.RemoveListener(ActivateShotButton);
        _refreshAimButton.onClick.RemoveListener(ActivateRefreshAimButton);
    }

    private void ActivateShotButton()
    {
        ShotPlayerEvent?.Invoke();
    }

    private void ActivateRefreshAimButton()
    {
        GlobalEventManager.SearchNewAimEvent.Invoke();
    }
}
