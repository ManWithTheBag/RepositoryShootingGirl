using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(SetPauseGame);
        _resumeButton.onClick.AddListener(ResumeGame);
    }
    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(SetPauseGame);
        _resumeButton.onClick.RemoveListener(ResumeGame);
    }

    private void Start()
    {
        _pausePanel.SetActive(false);
    }

    private void SetPauseGame()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        _pausePanel.SetActive(false);
    }
}
