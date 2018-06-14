using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMousePointer : MonoBehaviour {
    private RectTransform m_RectTransform;

	// Use this for initialization
	void Start () {
        m_RectTransform = GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
        m_RectTransform.transform.position = Input.mousePosition;

    }
}
