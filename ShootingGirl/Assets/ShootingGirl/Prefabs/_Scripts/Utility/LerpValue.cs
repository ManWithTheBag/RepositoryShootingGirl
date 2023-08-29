using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpValue 
{
    //TODO Do some with LerpValue

    //[SerializeField] private float _timeLearpingScoreInProgressBar;

    ////private ModelProgressBarFields _modelProgressBarFields;
    //private int _upperScoreLimit;
    //private float _smoothLearpValue = 0;
    //private float _currentLearpScore;
    //private int _newScoreValue;

    //private int _newValue;
    //private int _oldValue;
    //private int _currentValue;

    //public Coroutine _coroutine;

    //public event Action ChengeValueEvent;


    //public LearpValue(int oldValue, int newValue)
    //{
    //    _coroutine = new Coroutine();


    //    _newValue = newValue;
    //    _oldValue = oldValue;
    //}

    //public void SetValue()
    //{

    //}

    //public void StartCoroutine()
    //{

    //}

    //public void StopCoroutine()
    //{

    //}


    //private void OnRefreshModelProgressBar(int oldScoreValue, int newScoreValue)
    //{
    //    _newScoreValue = newScoreValue;

    //    StartCoroutine(LearpingScoreInProgressBar());
    //}


    //private IEnumerator LearpingScoreInProgressBar()
    //{

    //    for (float i = 0; i < 1; i += Time.deltaTime / _timeLearpingScoreInProgressBar)
    //    {
    //        _currentLearpScore = Mathf.Lerp(_smoothLearpValue, _newScoreValue, i);
    //        _modelProgressBarFields.TextCurrentScore.text = Mathf.Round(_currentLearpScore).ToString();
    //        _modelProgressBarFields.ImageModelProgressBar.fillAmount = _currentLearpScore / _upperScoreLimit;
    //        yield return null;
    //    }

    //    _modelProgressBarFields.TextCurrentScore.text = _newScoreValue.ToString();
    //    _smoothLearpValue = _newScoreValue;
    //}

}
