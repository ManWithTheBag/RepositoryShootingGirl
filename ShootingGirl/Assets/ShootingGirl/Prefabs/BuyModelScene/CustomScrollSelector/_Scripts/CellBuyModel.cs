using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBuyModel : AbsCell
{
    public override void SetupPlayerModelCell(AbsPlayerBaseModetState absPlayerBaseModetState)
    {
        base.SetupPlayerModelCell(absPlayerBaseModetState);
        //CreateModel(absPlayerBaseModetState.characterInfo.prefabOfCharacter);
    }

    //private void CreateModel(GameObject prefabOfCharacter)
    //{
    //    Instantiate(prefabOfCharacter, transform.position, Quaternion.identity);
    //}
}
