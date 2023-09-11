using System;
using System.Collections;
using UnityEngine;

public class LerpValue
{
    private Coroutine _routine;
    private float _timeLerpValue;
    private bool _isDoCoroutine;
    private float _currentLerpValue;


    public event Action<float> LerpChengedValueEvent;

    public LerpValue(float timeLerpValue)
    {
        _timeLerpValue = timeLerpValue;
    }

    public void SetNewValue(float oldValue, float newValue)
    {
        RefreshScore(oldValue, newValue);
    }

    public void StopCoroutine()
    {
        Coroutines.instanceLerpValue.StopRoutine(_routine);
    }

    private void RefreshScore(float oldValue, float newValue)
    {
        if (_isDoCoroutine == true)
        {
            Coroutines.instanceLerpValue.StopRoutine(_routine);

            oldValue = Mathf.RoundToInt(_currentLerpValue);
            _routine = Coroutines.instanceLerpValue.StartRoutine(LerpingScore(oldValue, newValue));
        }
        else
        {
            _routine = Coroutines.instanceLerpValue.StartRoutine(LerpingScore(oldValue, newValue));
        }
    }


    private IEnumerator LerpingScore(float oldScoreValue, float newScoreValue)
    {
        _isDoCoroutine = true;

        for (float i = 0; i < 1; i += Time.deltaTime / _timeLerpValue)
        {
            _currentLerpValue = Mathf.Lerp(oldScoreValue, newScoreValue, i);
            LerpChengedValueEvent?.Invoke(_currentLerpValue);
            yield return null;
        }

        LerpChengedValueEvent?.Invoke(Mathf.RoundToInt(newScoreValue));

        _isDoCoroutine = false;
    }

}
