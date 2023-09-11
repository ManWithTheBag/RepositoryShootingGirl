using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : AbsCell
{
    [SerializeField] [Min(0)] private float _timeLerpImage;
    [SerializeField] [Min(0)] private float _minAlpha;

    private Image _iconPlayerModel;

    public override void Awake()
    {
        base.Awake();
        _iconPlayerModel = GetComponent<Image>();
    }

    public override void SetupPlayerModelCell(AbsPlayerBaseModetState absPlayerBaseModetState)
    {
        base.SetupPlayerModelCell(absPlayerBaseModetState);
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
