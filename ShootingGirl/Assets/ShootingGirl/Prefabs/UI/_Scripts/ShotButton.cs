using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShotButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event Action<bool> ShotButtonStatusEvent;

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
}
