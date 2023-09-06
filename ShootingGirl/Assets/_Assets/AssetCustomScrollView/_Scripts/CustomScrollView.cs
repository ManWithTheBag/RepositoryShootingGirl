using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomScrollView : MonoBehaviour
{
    [SerializeField] ScrollView scrollView = default;
    [SerializeField] Text selectedItemInfo = default;

    private List<ItemData> itemDatasList = new();

    private void OnEnable()
    {
        GlobalEventManager.DiedPlayerModelEvent.AddListener(DisableDiedModel);
    }
    private void OnDisable()
    {
        GlobalEventManager.DiedPlayerModelEvent.RemoveListener(DisableDiedModel);
    }

    void Start()
    {
        CreateCell();
    }

    private void CreateCell()
    {
        itemDatasList.Clear();

        scrollView.OnSelectionChanged(OnSelectionChanged);

        for (int i = 0; i < PlayerModelSwitcher.s_playerModelStateDictionary.Values.Count; i++)
        {
            if (PlayerModelSwitcher.s_playerModelStateDictionary[(PlayerModelEnum)i].isDied == false)
            {
                //Debug.Log("ActiveModel: " + (PlayerModelEnum)i);
                Sprite tempImage = PlayerModelSwitcher.s_playerModelStateDictionary[(PlayerModelEnum)i].characterInfo.iconOfCharacter;

                ItemData itemDtata = new ItemData((PlayerModelEnum)i, "", tempImage);
                itemDatasList.Add(itemDtata);
            }
        }

        scrollView.UpdateData(itemDatasList);
        scrollView.SelectCell(0);
    }

    void OnSelectionChanged(int index)
    {
        selectedItemInfo.text = $"Selected item info: index {index}";
    }

    private void DisableDiedModel()
    {
        //CreateCell();


        //for (int i = 0; i < PlayerModelSwitcher.s_playerModelStateDictionary.Values.Count; i++)
        //{
        //    //if(PlayerModelSwitcher.s_playerModelStateDictionary[(PlayerModelEnum)i].isDied == true)
        //    //{

        //    //}
        //}
    }
                //if(itemDatasList.Count != 0)
                //{
                //    itemDatasList.RemoveAt(i);
                //}
}
