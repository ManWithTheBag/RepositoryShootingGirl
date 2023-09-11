using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDiedPanel : MonoBehaviour
{
    [SerializeField] private Button _restartGameButton;
    [SerializeField] private Button _loadBuyModelMenuButton;
    [SerializeField] private int _numberLoadScene;

    private void OnEnable()
    {
        _restartGameButton.onClick.AddListener(RestartGame);
        _loadBuyModelMenuButton.onClick.AddListener(LoadBuyModelMenuScene);
    }
    private void OnDisable()
    {
        _restartGameButton.onClick.RemoveListener(RestartGame);
        _loadBuyModelMenuButton.onClick.RemoveListener(LoadBuyModelMenuScene);
    }

    private void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    private void LoadBuyModelMenuScene() => SceneManager.LoadScene(_numberLoadScene);
}
