using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public static SceneLoader Instance
    {
        get; set;
    }


    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            LoadLevel("Level_1");
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            LoadLevel("Boss");
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            LoadLevel("Main_Menu");
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            LoadLevel("Win");
        }
    }

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }

    public void ResetLoadedScene()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildIndex);
    }
}
