using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerButtonController : MonoBehaviour
{
    [SerializeField] private ShotButton _shotButton;
    [SerializeField] private Image _overheatFillImage;
    [SerializeField] private Button _refreshAimButton;

    public ShotButton shotButton { get { return _shotButton; } private set { _shotButton = value; } }
    public Image overheatFillImage { get { return _overheatFillImage; } private set { _overheatFillImage = value; } }


    private void OnEnable()
    {
        _refreshAimButton.onClick.AddListener(ActivateRefreshAimButton);
    }
    private void OnDisable()
    {
        _refreshAimButton.onClick.RemoveListener(ActivateRefreshAimButton);
    }

    private void ActivateRefreshAimButton()
    {
        GlobalEventManager.SearchNewAimEvent.Invoke();
    }
}
