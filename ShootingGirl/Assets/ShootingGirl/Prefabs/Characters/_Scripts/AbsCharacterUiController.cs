using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsCharacterUiController : MonoBehaviour
{
    protected GameObject _uiController;
    protected AbsCharacter _thisAbsCharacter;
    protected TakingDamage _takingDamage;
    protected AbsUIBarFields _absUIBar;

    public virtual void Awake()
    {
        _uiController = GameObject.Find("UIController");
        _thisAbsCharacter = GetComponent<AbsCharacter>();
        _takingDamage = GetComponent<TakingDamage>();
    }


    public abstract void SetCurrentHealth(float currentHealth);


    //TODO chenge logic when willdo several players model
    protected void SetCurrentCharacterData()
    {
        _absUIBar.imageFill.fillAmount = (_takingDamage.currentHealth / _thisAbsCharacter.characterInfo.fullHealth);
        _absUIBar.currentText.text = _takingDamage.currentHealth.ToString();
        _absUIBar.upperLimitText.text = _thisAbsCharacter.characterInfo.fullHealth.ToString();
        _absUIBar.lowerLimitText.text = 0.ToString();
        _absUIBar.iconCharacter.sprite = _thisAbsCharacter.characterInfo.iconOfCharacter;
    }
}
