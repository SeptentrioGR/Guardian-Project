using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{

    public Button RestartGameButton;
    public Button ExitToMenuButton;

    private void OnEnable()
    {
        if (AudioManager.Instance)
        {
            AudioManager.Instance.PlaySoundSFX(Constants.WinMusic);
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
        try
        {
            SceneLoader.Instance.LoadLevel(Constants.WinScene);
        }
        catch
        {
            Debug.LogWarning("SceneLoader not found , use _Preloader scene");
        }
    }

    public void RestartGame()
    {
        try
        {
            SceneLoader.Instance.ResetLoadedScene();
        }
        catch
        {
            Debug.LogWarning("SceneLoader not found , use _Preloader scene");
        }
    }

}
