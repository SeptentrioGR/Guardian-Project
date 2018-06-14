using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpeMessageTrigger : MonoBehaviour {
    private bool Triggered;
    public string message;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Triggered)
        {
            SpeechBubble.Instance.Speek(message, 4);
            SpeechBubble.Instance.BlockToSaySomethingNew(Triggered);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Constants.PlayerTag)
        {
            if (!Triggered)
                Triggered = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Constants.PlayerTag)
        {
            if (Triggered)
            {
                Triggered = false;
                SpeechBubble.Instance.BlockToSaySomethingNew(Triggered);
            }
        }
    }
}
