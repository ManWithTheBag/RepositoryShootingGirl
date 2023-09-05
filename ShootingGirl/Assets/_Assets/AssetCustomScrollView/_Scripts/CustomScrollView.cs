using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomScrollView : MonoBehaviour
{
    [SerializeField] ScrollView scrollView = default;
    [SerializeField] Text selectedItemInfo = default;

    private List<ItemData> itemDatasList = new();

    void Start()
    {
        scrollView.OnSelectionChanged(OnSelectionChanged);

        for (int i = 0; i < PlayerModelSwitcher.s_playerModelStateDictionary.Values.Count; i++)
        {
            Sprite tempImage = PlayerModelSwitcher.s_playerModelStateDictionary[(PlayerModelEnum)i].characterInfo.iconOfCharacter;

            ItemData itemDtata = new ItemData("", tempImage);
            itemDatasList.Add(itemDtata);
        }

        scrollView.UpdateData(itemDatasList);
        scrollView.SelectCell(0);
    }

    void OnSelectionChanged(int index)
    {
        selectedItemInfo.text = $"Selected item info: index {index}";
    }
}
