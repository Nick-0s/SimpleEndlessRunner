using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Player _player;
    private CanvasGroup _gameOverGroup;

    private void Awake()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.interactable = false;
        _gameOverGroup.alpha = 0;
    }

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnPlayerDied()
    {
        Time.timeScale = 0;
        _gameOverGroup.alpha = 1;
        _gameOverGroup.interactable = true;
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
