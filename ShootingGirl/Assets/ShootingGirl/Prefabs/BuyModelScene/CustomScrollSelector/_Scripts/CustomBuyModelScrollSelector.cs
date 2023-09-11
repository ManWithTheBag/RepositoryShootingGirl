using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBuyModelScrollSelector : AbsCustomScrollSelector<CellBuyModel>
{
    public event Action<PlayerModelEnum> SetPlayerModelStateEvent;

    public override void SelectPlayerModel(PlayerModelEnum playerModelEnum)
    {
        SetPlayerModelStateEvent?.Invoke(playerModelEnum);
    }
}
