using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiftCounter : MonoBehaviour {

    public Text m_Text;
	// Update is called once per frame
	void Update () {
        if (GameManager.Instance)
        {
            if (GameManager.Instance.m_RiftRemaining > 0)
            {
                m_Text.text = string.Format("Rifts {0} / {1}", 3-GameManager.Instance.m_RiftRemaining, 3);
            }
            else
            {
                m_Text.text = "Area is Safe";
            }
        }
	}
}
