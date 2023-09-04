using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingDamage : MonoBehaviour
{
    //[SerializeField] private CommonGameInfo _commonGameInfo;

    //private AbsPlayerBaseModetState _currentPlayerModelState;
    //private GameObject _uiController;
    //private AbsCharacter _thisCharacter;
    //private ScoreController _scoreController;
    //private AbsCharacterUiController _absCharacterUiControler;
    //private float _currentHealth;
    //private bool _isDoCoroutine;
    //private float _currentLerpValue;

    //public float currentHealth { get { return _currentHealth; } private set { _currentHealth = value; } }

    //private void Awake()
    //{
    //    _thisCharacter = GetComponent<AbsCharacter>();
    //    _uiController = GameObject.Find("UIController");
    //    _scoreController = _uiController.GetComponent<ScoreController>();
    //    _absCharacterUiControler = GetComponent<AbsCharacterUiController>();
    //    _currentHealth = _thisCharacter.currentCharacterInfo.fullHealth;
    //}

    //private void OnEnable()
    //{
    //    GlobalEventManager.ChangePlayerModelStateEvent.AddListener(SetCurrentPlayerModelState);
    //}
    //private void OnDisable()
    //{
    //    GlobalEventManager.ChangePlayerModelStateEvent.RemoveListener(SetCurrentPlayerModelState);
    //}

    //private void SetCurrentPlayerModelState(PlayerModelEnum playerModelEnum)
    //{
    //    _currentPlayerModelState = PlayerModelSwitcher.s_playerModelStateDictionary[playerModelEnum];
    //    _currentHealth = _currentPlayerModelState.currentHealthThisModel;

    //    StopAllCoroutines();
    //    _absCharacterUiControler.SetCurrentHealth(_currentHealth);

    //}

    //public void TakeDamage(float damage)
    //{
    //    float oldHealthValue = _currentHealth;
    //    _currentHealth -= damage;

    //    SaveCurrentHealthThisModel(_currentHealth);

    //    StartLerpValues(oldHealthValue, _currentHealth);


    //    if (_currentHealth <= 0)
    //        DeathCharacter();
    //}

    //private void SaveCurrentHealthThisModel(float currentHealth)
    //{
    //    _currentPlayerModelState.SetCurrentHealthForThisModel(currentHealth);
    //}

    //private void StartLerpValues(float oldValue, float newValue)
    //{
    //    if (_isDoCoroutine == true)
    //    {
    //        StopAllCoroutines();
    //        StartCoroutine(LerpValue(oldValue, newValue));
    //    }
    //    else
    //    {
    //        StartCoroutine(LerpValue(oldValue, newValue));
    //    }
    //}

    //private IEnumerator LerpValue(float oldScoreValue, float newScoreValue)
    //{
    //    _isDoCoroutine = true;

    //    for (float i = 0; i < 1; i += Time.deltaTime / _commonGameInfo.timeLerpingValue)
    //    {
    //        _currentLerpValue = Mathf.Lerp(oldScoreValue, newScoreValue, i);
    //        _absCharacterUiControler.SetCurrentHealth(_currentLerpValue);
    //        yield return null;
    //    }

    //    _absCharacterUiControler.SetCurrentHealth(newScoreValue);

    //    _isDoCoroutine = false;
    //}

    //private void DeathCharacter()
    //{
    //    _thisCharacter.TotalRefresh();
    //    _scoreController.AddScore(_thisCharacter.currentCharacterInfo.scoreInEnemy);
    //    _currentHealth = _thisCharacter.currentCharacterInfo.fullHealth;
    //}
}
