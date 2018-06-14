using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeElement : MonoBehaviour {
    public Image LifeImage;

    public void LifeLost(bool value)
    {
        LifeImage.enabled = value;
    }
}
