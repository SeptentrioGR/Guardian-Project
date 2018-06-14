using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCollectedUI : MonoBehaviour {
    public Text         text;
    private GameManager gameManager;

    void Start () 
    {
        gameManager = GameManager.Instance;
    }
	
	void Update () {
        if (gameManager == null)
        {
            return;
        }
        int starCollected = gameManager.StarCollected;
        int totalStars = gameManager.TotalStars;
        text.text = string.Format("{0} / {1}", starCollected, totalStars);

    }
}
