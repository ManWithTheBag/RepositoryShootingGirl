using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemData 
{
    public Sprite _imagePlayerModel;
    public string Message { get; }
    public int IdItem { get; }

    public ItemData(string message, Sprite imagePlayerMOdel)
    {
        Message = message;
        _imagePlayerModel = imagePlayerMOdel;
    }
}
