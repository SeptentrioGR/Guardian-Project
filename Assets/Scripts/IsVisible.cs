using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisible : MonoBehaviour {
    private TimeRift timeRiftScript;

    private bool riftIsOpened;

    public void Start()
    {
        timeRiftScript = GetComponentInParent<TimeRift>();
    }

    private void OnBecameVisible()
    {
        if (!riftIsOpened)
        {
            riftIsOpened = true;
            Debug.Log(gameObject.name + "is Visible");
            timeRiftScript.StartRift();
        }
    }

    private void OnBecameInvisible()
    {
        Debug.Log(gameObject.name + "is Inivisble");
    }
}
