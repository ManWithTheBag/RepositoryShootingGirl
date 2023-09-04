using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUiController : AbsCharacterUiController
{
    private AimsPoolContainer _aimsPoolContainer;
    private bool _isSelected;
    private GameObject _thisGO;

    public override void Awake()
    {
        base.Awake();
        _aimsPoolContainer = GameObject.Find("CaractersController").GetComponent<AimsPoolContainer>();
        _absUIBar = _uiController.GetComponent<EnemyHealthBarFields>();
        _thisGO = gameObject;
    }

    private void OnEnable()
    {
        _aimsPoolContainer.FoundNearestAimOfPlayerEvent += CheckAimSelected;
    }
    private void OnDisable()
    {
        _aimsPoolContainer.FoundNearestAimOfPlayerEvent -= CheckAimSelected;
    }

    private void CheckAimSelected(Transform nearestAimOfPlayer)
    {
        if(GameObject.ReferenceEquals(nearestAimOfPlayer.gameObject, _thisGO.gameObject))
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
