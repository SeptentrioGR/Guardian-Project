using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    public GameObject[] DoorStatus;
    private bool IsInteractable = true;
    public bool Open;

    public bool CanInteractWith
    {
        get
        {
            return IsInteractable;
        }

        set
        {
            IsInteractable = value;
        }
    }

    public void Action()
    {
        Debug.Log("Action");
        if (!Open)
        {
            Open = !Open;
        }else if (Open)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Update()
    {
        DoorStatus[0].SetActive(false);
        DoorStatus[1].SetActive(false);

        if (Open)
        {
            DoorStatus[0].SetActive(true);
        }
        else
        {
            DoorStatus[1].SetActive(true);
        }
    }
}
