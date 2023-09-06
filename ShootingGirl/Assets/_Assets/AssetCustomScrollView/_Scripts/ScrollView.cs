using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScrollView : FancyScrollView<ItemData, Context>
{
    [SerializeField] Scroller scroller = default;
    [SerializeField] GameObject cellPrefab = default;

    public event Action<int> SelectionModelChangedEvent;
    public UnityEvent<int> SetPlayerModelStateEvent;

    protected override GameObject CellPrefab => cellPrefab;

    protected override void Initialize()
    {
        base.Initialize();

        Context.OnCellClicked = SelectCell;

        scroller.OnValueChanged(UpdatePosition);
        scroller.OnSelectionChanged(UpdateSelection);
    }

    void UpdateSelection(int index)
    {
        if (Context.SelectedIndex == index)
        {
            return;
        }

        Context.SelectedIndex = index;
        Refresh();

        SelectionModelChangedEvent?.Invoke(index);

        //TODO select a new model
        SetPlayerModelStateEvent?.Invoke(index);
    }

    public void UpdateData(IList<ItemData> items)
    {
        UpdateContents(items);
        scroller.SetTotalCount(items.Count);
    }

    public void OnSelectionChanged(Action<int> callback)
    {
        SelectionModelChangedEvent = callback;
    }

    //public void SelectNextCell()
    //{
    //    SelectCell(Context.SelectedIndex + 1);
    //}

    //public void SelectPrevCell()
    //{
    //    SelectCell(Context.SelectedIndex - 1);
    //}

    public void SelectCell(int index)
    {
        if (index < 0 || index >= ItemsSource.Count || index == Context.SelectedIndex)
        {
            return;
        }

        UpdateSelection(index);
        scroller.ScrollTo(index, 0.35f, EaseEnum.OutCubic);
        SetPlayerModelStateEvent?.Invoke(index);
    }
}

