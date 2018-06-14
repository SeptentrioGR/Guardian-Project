using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRiftExit : MonoBehaviour, IInteractable
{
    private bool IsInteractable = true;
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
        GenerateTowerOfPlatforms.Instance.TeleportBack();
    }

    public void EnterRift()
    {

    }
}
