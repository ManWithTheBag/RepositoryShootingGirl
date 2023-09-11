using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUiController : AbsCharacterUiController
{
    private bool _isSelected;
    private GameObject _thisGO;

    public override void Awake()
    {
        base.Awake();
        _absUIBar = _uiController.GetComponent<EnemyHealthBarFields>();
        _thisGO = gameObject;
    }

    private void OnEnable()
    {
        GlobalEventManager.GetNewAimForPlayerEvent.AddListener(CheckAimSelected);
    }
    private void OnDisable()
    {
        GlobalEventManager.GetNewAimForPlayerEvent.RemoveListener(CheckAimSelected);
    }

    private void CheckAimSelected(Transform aimForPlayer)
    {
        if(GameObject.ReferenceEquals(aimForPlayer.gameObject, _thisGO.gameObject))
        {
            _isSelected = true;
            SetCurrentCharacterData();
        }
        else
        {
            _isSelected = false;
        }
    }

    public override void SetCurrentHealth(float currentHealth)
    {
        if (_isSelected)
        {
            _absUIBar.currentText.text = Mathf.RoundToInt(currentHealth).ToString();
            _absUIBar.imageFill.fillAmount = currentHealth / _thisAbsCharacter.currentCharacterInfo.fullHealth;
        }
    }

}
