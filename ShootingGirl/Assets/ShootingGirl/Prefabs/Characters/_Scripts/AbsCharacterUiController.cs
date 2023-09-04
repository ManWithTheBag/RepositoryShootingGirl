using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsCharacterUiController : MonoBehaviour
{
    protected GameObject _uiController;
    protected AbsCharacter _thisAbsCharacter;
    protected AbsTakingDamage _absTakingDamage;
    protected AbsUIBarFields _absUIBar;

    public virtual void Awake()
    {
        _uiController = GameObject.Find("UIController");
        _thisAbsCharacter = GetComponent<AbsCharacter>();
        _absTakingDamage = GetComponent<AbsTakingDamage>();
    }


    public abstract void SetCurrentHealth(float currentHealth);


    protected void SetCurrentCharacterData()
    {
        _absUIBar.imageFill.fillAmount = (_absTakingDamage.currentHealth / _thisAbsCharacter.currentCharacterInfo.fullHealth);
        _absUIBar.currentText.text = _absTakingDamage.currentHealth.ToString();
        _absUIBar.upperLimitText.text = _thisAbsCharacter.currentCharacterInfo.fullHealth.ToString();
        _absUIBar.lowerLimitText.text = 0.ToString();
        _absUIBar.iconCharacter.sprite = _thisAbsCharacter.currentCharacterInfo.iconOfCharacter;
    }
}
