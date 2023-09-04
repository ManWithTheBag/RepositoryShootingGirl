using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUiController : AbsCharacterUiController
{
    public override void Awake()
    {
        base.Awake();
        _absUIBar = _uiController.GetComponent<PlayerHealthBarFields>();
    }

    private void OnEnable()
    {
        GlobalEventManager.ChangePlayerModelStateEvent.AddListener(UpdateUiCharacterData);
    }
    private void OnDisable()
    {
        GlobalEventManager.ChangePlayerModelStateEvent.RemoveListener(UpdateUiCharacterData);
    }

    private void Start()
    {
        SetCurrentCharacterData();
    }

    private void UpdateUiCharacterData(PlayerModelEnum playerModelEnum)
    {
        SetCurrentCharacterData();
    }

    public override void SetCurrentHealth(float currentHealth)
    {
        _absUIBar.currentText.text = Mathf.RoundToInt(currentHealth).ToString();
        _absUIBar.imageFill.fillAmount = currentHealth / _thisAbsCharacter.currentCharacterInfo.fullHealth;
    }


}
