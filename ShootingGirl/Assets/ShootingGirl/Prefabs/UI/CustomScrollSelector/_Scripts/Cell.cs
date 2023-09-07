using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] [Min(0)] private float _timeLerpImage;
    [SerializeField] [Min(0)] private float _minAlpha;

    private CharacterInfo _characterInfo;
    private AbsPlayerBaseModetState _absPlayerBaseModetState;
    private Image _iconPlayerModel;
    private Transform _cellTransform;

    public CharacterInfo characterInfo { get { return _characterInfo; } private set { _characterInfo = value; } }
    public AbsPlayerBaseModetState absPlayerBaseModetState { get { return _absPlayerBaseModetState; } private set { _absPlayerBaseModetState = value; } }
    public Transform cellTransform { get { return _cellTransform; } private set { _cellTransform = value; }}


    private void Awake()
    {
        _cellTransform = transform;
        _iconPlayerModel = GetComponent<Image>();
    }

    public void SetupPlayerModelCell(AbsPlayerBaseModetState absPlayerBaseModetState)
    {
        _absPlayerBaseModetState = absPlayerBaseModetState;
        _characterInfo = absPlayerBaseModetState.characterInfo;

        SetupCellImage();
    } 

    private void SetupCellImage()
    {
        _iconPlayerModel.sprite = _characterInfo.iconOfCharacter;
        _iconPlayerModel.color = new Color(_iconPlayerModel.color.r, _iconPlayerModel.color.g, _iconPlayerModel.color.b, _minAlpha);
    }


    #region Lerp image

    public void LerpMaxAlphaCellImage()
    {
        StartCoroutine(LerpImage(1));
    }
    public void LerpMinAlphaCellImage()
    {
        StartCoroutine(LerpImage(_minAlpha));
    }

    public IEnumerator LerpImage(float endValue)
    {
        float elapsedTime = 0;
        float startValue = _iconPlayerModel.color.a;
        while (elapsedTime < _timeLerpImage)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, endValue, elapsedTime / _timeLerpImage);
            _iconPlayerModel.color = new Color(_iconPlayerModel.color.r, _iconPlayerModel.color.g, _iconPlayerModel.color.b, newAlpha);
            yield return null;
        }
        
        _iconPlayerModel.color = new Color(_iconPlayerModel.color.r, _iconPlayerModel.color.g, _iconPlayerModel.color.b, endValue);
    }
    #endregion
}
