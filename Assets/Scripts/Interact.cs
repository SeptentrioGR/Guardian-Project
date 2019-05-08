using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public interface IInteractable
{
    bool CanInteractWith { get;}
    void Action();
}



public class Interact : MonoBehaviour
{
    public delegate EventArgs InteractionEvent();
    public event InteractionEvent Interacted;

    private bool ActionAvailable;
    private bool KeyPressed;
    private float ClickEventTimer;
    private float ClickEventDelay = .25f;

    public GameObject InteractPrefab;
    public GameObject InteractGO;
    public Vector3 offset;

    private void Start()
    {
        if(InteractGO == null)
        {
            InteractGO = Instantiate(InteractPrefab);
        }

        ClickEventTimer = ClickEventDelay;
    }

    private void Update()
    {
        if (KeyPressed)
        {
            ClickEventTimer -= Time.deltaTime;
            if (ClickEventTimer < 0)
            {
                ClickEventTimer = ClickEventDelay;
                KeyPressed = false;
            }
        }
        InteractMessage interactMessage = InteractGO.GetComponent<InteractMessage>();
        interactMessage.SetMessage(string.Format("ENTER TO CLOSE RIFT", 0));
        InteractGO.SetActive(ActionAvailable);
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null && interactable.CanInteractWith)
        {
            ActionAvailable = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if (interactable != null && interactable.CanInteractWith)
        {
            ActionAvailable = true;
            InteractGO.transform.position = collision.gameObject.transform.localPosition + offset;
            if (CrossPlatformInputManager.GetButtonDown("Shoot") && !KeyPressed)
            {
                KeyPressed = true;
                collision.GetComponent<IInteractable>().Action();
 
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ActionAvailable = false;
    }

}
