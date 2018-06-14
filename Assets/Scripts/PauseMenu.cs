using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {


    public Button RestartGameButton;
    public Button ExitToMenuButton;

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
            SceneLoader.Instance.LoadLevel(Constants.MainScene);
            if(Time.timeScale == 0)
            {
                GameManager.Instance.Pause();
            }
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
            if (Time.timeScale == 0)
            {
                GameManager.Instance.Pause();
            }
        }
        catch
        {
            Debug.LogWarning("SceneLoader not found , use _Preloader scene");
        }
    }
}
