using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG_Go_to :MonoBehaviour,IInteractable {
    public GameObject Destination;
    public bool IsAvailableForInteraction;

    public bool CanInteractWith
    {
        get
        {
            return IsAvailableForInteraction;
        }
        set
        {
            IsAvailableForInteraction = value;
        }
    }

    public void Action()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = Destination.transform.position;
    }
    
}
