using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private int _numberLoadScene;
    [SerializeField] private Button _loadSceneButton;

    private void OnEnable()
    {
        _loadSceneButton.onClick.AddListener(TransitTo);
    }
    private void OnDisable()
    {
        _loadSceneButton.onClick.RemoveListener(TransitTo);
    }


    private void TransitTo() => SceneManager.LoadScene(_numberLoadScene);
    
}
