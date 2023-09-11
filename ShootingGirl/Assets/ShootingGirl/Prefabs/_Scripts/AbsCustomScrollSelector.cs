using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbsCustomScrollSelector<T> : MonoBehaviour where T : AbsCell
{
    [SerializeField] private GameObject _scrollbarGO;
    [SerializeField] private GameObject _cellContent;
    [SerializeField] private T _cell;
    [SerializeField] private float _scaleSelectedCell;
    [SerializeField] private float _scaleHidendCell;
    [SerializeField] private float _smoothCellLerp;

    protected List<T> _cellList = new();
    protected PlayerModelEnum _playerModelEnum;

    private Scrollbar _scrollbar;
    private float _distance;
    private float scroll_pos = 0;
    float[] _pos;
    private bool _isLerpLastCell;

    public Scrollbar scrollbar { get { return _scrollbar; } private set { _scrollbar = value; } }

    private void Awake()
    {
        _scrollbar = _scrollbarGO.GetComponent<Scrollbar>();
    }

    private void Start()
    {
        CreateNewCellDictionary();
        _playerModelEnum = PlayerModelEnum.Ememy;
    }

    protected void CreateNewCellDictionary()
    {
        for (int i = 0; i < PlayerModelSwitcher.s_playerModelStateDictionary.Count; i++)
        {
            if (PlayerModelSwitcher.s_playerModelStateDictionary[(PlayerModelEnum)i].isDied == false)
            {
                T tempCell = Instantiate(_cell, _cellContent.transform);
                AbsPlayerBaseModetState absPlayerBaseModetState = PlayerModelSwitcher.s_playerModelStateDictionary[(PlayerModelEnum)i];
                tempCell.SetupPlayerModelCell(absPlayerBaseModetState);
                tempCell.cellTransform.localScale = new Vector2(_scaleHidendCell, _scaleHidendCell);

                _cellList.Add(tempCell);
            }
        }

        FixNotCalllastPlayerModel();

        _pos = new float[_cellList.Count];
    }


    void Update()
    {
        CalculateDistance();
        LerpCellPosition();
        LerpCellScale();

        FixLerCellpLastModel();
    }

    private void CalculateDistance()
    {
        _distance = 1f / (_pos.Length - 1f);
    }

    private void LerpCellPosition()
    {
        for (int i = 0; i < _pos.Length; i++)
        {
            _pos[i] = _distance * i;
            
            //if(i == 0)
        }

        if (Input.GetMouseButton(0))
            scroll_pos = _scrollbar.value;
        else
        {
            for (int i = 0; i < _pos.Length; i++)
            {
                if (scroll_pos < _pos[i] + (_distance / 2) && scroll_pos > _pos[i] - (_distance / 2))
                {
                    Debug.Log(_scrollbar.value);
                    _scrollbar.value = Mathf.Lerp(_scrollbar.value, _pos[i], _smoothCellLerp);
                }
            }
        }

    }
    private void LerpCellScale()
    {
        for (int i = 0; i < _pos.Length; i++)
        {
            if (scroll_pos < _pos[i] + (_distance / 2) && scroll_pos > _pos[i] - (_distance / 2))
            {
                if (_cellList[i] != null)
                {
                    _cellList[i].cellTransform.localScale = Vector2.Lerp(_cellList[i].cellTransform.localScale, new Vector2(_scaleSelectedCell, _scaleSelectedCell), _smoothCellLerp);
                    SelectNewModel(_cellList[i].characterInfo.typePlayerModel);
                }


                for (int j = 0; j < _pos.Length; j++)
                {
                    if (j != i && _cellList[j] != null)
                    {
                        _cellList[j].cellTransform.localScale = Vector2.Lerp(_cellList[j].cellTransform.localScale, new Vector2(_scaleHidendCell, _scaleHidendCell), _smoothCellLerp);
                    }
                }
            }
        }
    }


    #region Fix call player model

    private void FixNotCalllastPlayerModel()
    {
        if (_cellList.Count == 1 || _cellList.Count == PlayerModelSwitcher.s_playerModelStateDictionary.Count)
        {
            SelectNewModel(_cellList[0].characterInfo.typePlayerModel);
        }

        if (_cellList.Count == 1)
            _isLerpLastCell = true;
    }

    private void FixLerCellpLastModel()
    {
        if (_isLerpLastCell && _cellList.Count != 0)
        {
            _cellList[0].cellTransform.localScale = Vector2.Lerp(_cellList[0].cellTransform.localScale, new Vector2(_scaleSelectedCell, _scaleSelectedCell), _smoothCellLerp);
        }
    }

    #endregion


    private void SelectNewModel(PlayerModelEnum playerModelEnum)
    {
        if (_playerModelEnum != playerModelEnum)
            SelectPlayerModel(playerModelEnum);
        

        _playerModelEnum = playerModelEnum;
    }

    public abstract void SelectPlayerModel(PlayerModelEnum playerModelEnum);
}
