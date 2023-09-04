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

    [SerializeField] private Button _activalePlayerWithGun;
    [SerializeField] private Button _activatePlayerWithGunmachine;
    [SerializeField] private Button _activatePlayerWothRocket;


    public ShotButton shotButton { get { return _shotButton; } private set { _shotButton = value; } }
    public Image overheatFillImage { get { return _overheatFillImage; } private set { _overheatFillImage = value; } }

    
    public Button activalePlayerWithGun { get { return _activalePlayerWithGun; } private set { _activalePlayerWithGun = value; } }
    public Button activatePlayerWithGunmachine { get { return _activatePlayerWithGunmachine; } private set { _activatePlayerWithGunmachine = value; } }
    public Button activatePlayerWothRocket { get { return _activatePlayerWothRocket; } private set { _activatePlayerWothRocket = value; } }


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
