using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiBuyMenyField : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _totalScoreText;

    public TextMeshProUGUI totalScoreText { get { return _totalScoreText; } private set { _totalScoreText = value; } }
}
