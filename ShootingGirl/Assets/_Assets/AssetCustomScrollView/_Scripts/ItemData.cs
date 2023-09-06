using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemData 
{
    public Sprite _imagePlayerModel;
    public string Message { get; }
    public PlayerModelEnum _playerModelEnum;
    public GameObject _cellGO;

    public ItemData(PlayerModelEnum playerModelEnum, string message, Sprite imagePlayerMOdel)
    {
        _playerModelEnum = playerModelEnum;
        Message = message;
        _imagePlayerModel = imagePlayerMOdel;
    }
}
