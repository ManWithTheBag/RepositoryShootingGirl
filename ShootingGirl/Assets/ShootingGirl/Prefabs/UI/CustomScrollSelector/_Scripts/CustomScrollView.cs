using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomScrollView : MonoBehaviour
{
    [SerializeField] private GameObject _scrollbar;
    [SerializeField] private GameObject _cellContent;
    [SerializeField] private Cell _cell;
    [SerializeField] private float _scaleSelectedCell;
    [SerializeField] private float _scaleHidendCell;
    [SerializeField] private float _smoothCellLerp;

    //private Dictionary<int, Cell> _cellDictionary = new();
    private List<Cell> _cellList = new();
    private float _distance;
    private PlayerModelEnum _playerMOdelEnum;
    private float scroll_pos = 0;
    float[] _pos;

    private bool _isLerpLastCell;

    public event Action<PlayerModelEnum> SetPlayerModelStateEvent;

    private void OnEnable()
    {
        GlobalEventManager.DiedPlayerModelEvent.AddListener(DiedPlayerModel);
    }
    private void OnDisable()
    {
        GlobalEventManager.DiedPlayerModelEvent.RemoveListener(DiedPlayerModel);
    }


    private void Start()
    {
        CreateNewCellDictionary();
    }

    private void CreateNewCellDictionary()
    {
        for (int i = 0; i < PlayerModelSwitcher.s_playerModelStateDictionary.Count; i++)
        {
            if(PlayerModelSwitcher.s_playerModelStateDictionary[(PlayerModelEnum)i].isDied == false)
            {
                Cell tempCell = Instantiate(_cell, _cellContent.transform);
                AbsPlayerBaseModetState absPlayerBaseModetState = PlayerModelSwitcher.s_playerModelStateDictionary[(PlayerModelEnum)i];
                tempCell.SetupPlayerModelCell(absPlayerBaseModetState);
                tempCell.cellTransform.localScale = new Vector2(_scaleHidendCell, _scaleHidendCell);

                _cellList.Add(tempCell);
            }
        }

        FixNotCalllastPlayerModel();

        _pos = new float[_cellList.Count];
    }


    private void DiedPlayerModel()
    {
        foreach (Cell item in _cellList)
            Destroy(item.gameObject);
        
        _cellList.Clear();
        CreateNewCellDictionary();
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
            _pos[i] = _distance * i;

        if (Input.GetMouseButton(0))
            scroll_pos = _scrollbar.GetComponent<Scrollbar>().value;
        else
        {
            for (int i = 0; i < _pos.Length; i++)
            {
                if (scroll_pos < _pos[i] + (_distance / 2) && scroll_pos > _pos[i] - (_distance / 2))
                {
                    _scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(_scrollbar.GetComponent<Scrollbar>().value, _pos[i], _smoothCellLerp);
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
                if(_cellList[i] != null)
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
    private void LerpCellColor(PlayerModelEnum playerModelEnum)
    {
        foreach (Cell item in _cellList)
        {
            if (item.characterInfo.typePlayerModel == playerModelEnum)
                item.LerpMaxAlphaCellImage();
            else
                item.LerpMinAlphaCellImage();
        }
    }

    private void FixNotCalllastPlayerModel()
    {
        if (_cellList.Count == 1 || _cellList.Count == PlayerModelSwitcher.s_playerModelStateDictionary.Count)
        {
            SelectNewModel(_cellList[0].characterInfo.typePlayerModel);
            LerpCellColor(_cellList[0].characterInfo.typePlayerModel);
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
        if(_playerMOdelEnum != playerModelEnum)
        {
            SetPlayerModelStateEvent?.Invoke(playerModelEnum);
            LerpCellColor(playerModelEnum);
        }
        
        _playerMOdelEnum = playerModelEnum;
    }

}
