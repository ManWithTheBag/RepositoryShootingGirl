using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsTakingDamage : MonoBehaviour
{
    [SerializeField] private CommonGameInfo _commonGameInfo;

    protected AbsCharacter _thisCharacter;
    protected float _currentHealth;
    protected AbsCharacterUiController _absCharacterUiControler;

    private bool _isDoCoroutine;
    private float _currentLerpValue;

    public float currentHealth { get { return _currentHealth; } private set { _currentHealth = value; } }

    public virtual void Awake()
    {
        _thisCharacter = GetComponent<AbsCharacter>();
        _absCharacterUiControler = GetComponent<AbsCharacterUiController>();
        _currentHealth = _thisCharacter.currentCharacterInfo.fullHealth;
    }


    public virtual void TakeDamage(float damage)
    {
        float oldHealthValue = _currentHealth;
        _currentHealth -= damage;

        StartLerpValues(oldHealthValue, _currentHealth);

        if (_currentHealth <= 0)
            DeathCharacter();
    }


    #region Lerp Section

    private void StartLerpValues(float oldValue, float newValue)
    {
        if (_isDoCoroutine == true)
        {
            StopAllCoroutines();
            StartCoroutine(LerpValue(oldValue, newValue));
        }
        else
        {
            StartCoroutine(LerpValue(oldValue, newValue));
        }
    }

    private IEnumerator LerpValue(float oldScoreValue, float newScoreValue)
    {
        _isDoCoroutine = true;

        for (float i = 0; i < 1; i += Time.deltaTime / _commonGameInfo.timeLerpingValue)
        {
            _currentLerpValue = Mathf.Lerp(oldScoreValue, newScoreValue, i);
            _absCharacterUiControler.SetCurrentHealth(_currentLerpValue);
            yield return null;
        }

        _absCharacterUiControler.SetCurrentHealth(newScoreValue);

        _isDoCoroutine = false;
    }

    #endregion


    public virtual void DeathCharacter()
    {
        _thisCharacter.TotalRefresh();
        _currentHealth = _thisCharacter.currentCharacterInfo.fullHealth;
    }
}
