using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    void Start()
    {
        SceneLoader.Instance.LoadLevel(Constants.MainScene);
    }
}
