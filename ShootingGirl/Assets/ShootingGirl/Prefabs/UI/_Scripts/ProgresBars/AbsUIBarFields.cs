using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbsUIBarFields : MonoBehaviour
{
    [field: SerializeField] public Image imageFill { get; private set; }
    [field: SerializeField] public TextMeshProUGUI currentText { get; private set; }
    [field: SerializeField] public TextMeshProUGUI upperLimitText { get; private set; }
    [field: SerializeField] public TextMeshProUGUI lowerLimitText { get; private set; }
    [field: SerializeField] public Image iconCharacter { get; private set; }

}
