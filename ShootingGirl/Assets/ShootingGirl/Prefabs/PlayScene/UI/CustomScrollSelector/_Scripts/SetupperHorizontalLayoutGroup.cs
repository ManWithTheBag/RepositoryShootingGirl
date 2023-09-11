using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupperHorizontalLayoutGroup : MonoBehaviour
{
    [SerializeField] private RectTransform _cellContainerRectTransform;
    [SerializeField] private RectTransform _cellRectTransform;
    private HorizontalLayoutGroup _horizontalLayoutGroup;

    private void Awake()
    {
        _horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
    }

    private void Start()
    {
        Settup();
    }
    private void Settup()
    {
        float padding = Mathf.Abs(_cellContainerRectTransform.anchoredPosition.x) - (_cellRectTransform.rect.width / 2);

        _horizontalLayoutGroup.padding.left = Mathf.RoundToInt(padding);
        _horizontalLayoutGroup.padding.right = Mathf.RoundToInt(padding);
    }
}
