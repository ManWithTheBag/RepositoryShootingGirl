using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : FancyCell<ItemData, Context>
{
    [SerializeField] Animator animator = default;
    [SerializeField] Text message = default;
    [SerializeField] Image image = default;
    [SerializeField] Button button = default;

    static class AnimatorHash
    {
        public static readonly int Scroll = Animator.StringToHash("scroll");
    }

    public override void Initialize()
    {
        button.onClick.AddListener(() => Context.OnCellClicked?.Invoke(Index));
    }

    public override void UpdateContent(ItemData itemData)
    {
        itemData._cellGO = gameObject;

        message.text = itemData.Message;
        image.sprite = itemData._imagePlayerModel;


        // Do som animation icon when selecterd here

        //var selected = Context.SelectedIndex == Index;
        //image.color = selected
        //    ? new Color32(0, 255, 255, 100)
        //    : new Color32(255, 255, 255, 77);
    }

    public override void UpdatePosition(float position)
    {
        currentPosition = position;

        if (animator.isActiveAndEnabled)
        {
            animator.Play(AnimatorHash.Scroll, -1, position);
        }

        animator.speed = 0;
    }


    float currentPosition = 0;

    void OnEnable() => UpdatePosition(currentPosition);
}
