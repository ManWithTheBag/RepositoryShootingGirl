using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomScrollView : AbsCustomScrollSelector<Cell>
{

    public event Action<PlayerModelEnum> SetPlayerModelStateEvent;

    private void OnEnable()
    {
        GlobalEventManager.DiedModelEvent.AddListener(DiedPlayerModel);
    }
    private void OnDisable()
    {
        GlobalEventManager.DiedModelEvent.RemoveListener(DiedPlayerModel);
    }

    private void DiedPlayerModel()
    {
        foreach (Cell item in _cellList)
            Destroy(item.gameObject);
        
        _cellList.Clear();
        CreateNewCellDictionary();
    }

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

    public override void SelectPlayerModel(PlayerModelEnum playerModelEnum) 
    {
        SetPlayerModelStateEvent?.Invoke(playerModelEnum);
        LerpCellColor(playerModelEnum);
    }
}
