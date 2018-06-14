using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class DEBUG_FLY : MonoBehaviour {
    public bool FlyMode = false;
    public PlatformController platformController;
    public float speed;
    public Rigidbody2D rb;

    public KeyCode enableKey;
    void Update () {

        if (Input.GetKeyDown(enableKey)){
            FlyMode = !FlyMode;
        }

        if (!FlyMode)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            platformController.enabled = true;
        }
        else
        {
            platformController.enabled = false;
            rb.bodyType = RigidbodyType2D.Static;
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            Vector2 pos = transform.position;
            pos.y += v * speed * Time.deltaTime;
            pos.x += h * speed * Time.deltaTime;
            transform.position = pos;
        }
    }
}
