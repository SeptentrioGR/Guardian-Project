using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteTextCanvasWidget : Singleton<CompleteTextCanvasWidget> {
    public GameObject m_Text;
	public void ShowCompleteMissionMessage()
    {
        m_Text.SetActive(true);
    }
}
