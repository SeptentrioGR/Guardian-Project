using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageTrigger : MonoBehaviour {
    private bool Triggered;
    public GameObject RequrimentsMessage;

    private void Update()
    {
        RequrimentsMessage.SetActive(Triggered);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Triggered)
        {
            RequrimentsMessage.SetActive(true);
            SpeechBubble.Instance.Speek("Area is not Safe yet", 4);
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
