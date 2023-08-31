using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUiController : AbsCharacterUiController
{
    public override void Awake()
    {
        base.Awake();
        _absUIBar = _uiController.GetComponent<PlayerHealthBar>();
    }

    private void Start()
    {
        SetCurrentCharacterData();
    }

    public override void SetCurrentHealth(float currentHealth)
    {
        _absUIBar.currentText.text = currentHealth.ToString();
        _absUIBar.imageFill.fillAmount = currentHealth / _thisAbsCharacter.characterInfo.fullHealth;
    }


}
