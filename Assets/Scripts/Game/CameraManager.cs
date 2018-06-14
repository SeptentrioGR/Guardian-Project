using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public void Update()
    {
        transform.localPosition = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition = Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition = Vector3.down;
        }
    }
}
