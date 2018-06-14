using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        SceneLoader.Instance.LoadLevel(name);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

}