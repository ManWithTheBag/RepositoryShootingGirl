using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShotButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event Action<bool> ShotButtonStatusEvent;
    public event Action ShotButtonOnClickEvent;

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(ClickShotButton);
    }
    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(ClickShotButton);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        SetShotButtonStatus(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        SetShotButtonStatus(false);
    }

    private void SetShotButtonStatus(bool status )
    {
        ShotButtonStatusEvent?.Invoke(status);
    }

    private void ClickShotButton()
    {
        ShotButtonOnClickEvent?.Invoke();
    }
}
