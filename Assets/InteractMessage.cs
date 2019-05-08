using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractMessage : MonoBehaviour
{
    public Text Message;

    public void SetMessage(string message)
    {
        Message.text = message;
    }
}
