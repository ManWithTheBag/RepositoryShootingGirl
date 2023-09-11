using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyModelMenu : MonoBehaviour
{
    [SerializeField] private UiBuyMenyField _uiBuyMenyField;
    private Storage _storage;


    private void Awake()
    {
        _storage = GameObject.Find("StorageGameData").GetComponent<Storage>();
    }

    private void Start()
    {
        _uiBuyMenyField.totalScoreText.text = _storage.totalScore.ToString();
    }
}
