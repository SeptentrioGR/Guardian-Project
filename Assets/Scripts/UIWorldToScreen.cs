using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWorldToScreen : MonoBehaviour {
    public GameObject user;
    public Vector3 offset;


    void Update()
    {
        transform.localPosition = Camera.main.WorldToScreenPoint(user.transform.localPosition) + offset;
    }
}
