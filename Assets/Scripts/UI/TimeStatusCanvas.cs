using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeStatusCanvas : MonoBehaviour { 
    public Text m_TimeStatusText;
    public void UpdateText(string text)
    {
        m_TimeStatusText.text = text;
    }
}
