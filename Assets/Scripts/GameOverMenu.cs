using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{

    public Button RestartGameButton;
    public Button ExitToMenuButton;
    private void OnEnable()
    {
        if (AudioManager.Instance)
        {
            AudioManager.Instance.PlaySoundSFX(Constants.LoseMusic);
            AudioManager.Instance.StopAllMusic();
        }
    }
    void Start()
    {
        RestartGameButton.onClick.AddListener(() =>
        {
            RestartGame();
        });

        ExitToMenuButton.onClick.AddListener(() =>
        {
            ExitToMenu();
        });
    }

    public void ExitToMenu()
    {
        if (SceneLoader.Instance)
            SceneLoader.Instance.LoadLevel(Constants.MainScene);
    }

    public void RestartGame()
    {
        if (SceneLoader.Instance)
            SceneLoader.Instance.ResetLoadedScene();
    }

}
