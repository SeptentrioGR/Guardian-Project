using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitDoor : MonoBehaviour {
    private bool        open;
    private Game         game;
    private GameManager gameManager;
    public Text ExitSign;
    public AudioSource source;

	// Use this for initialization
	void Start () {
        gameManager = GameManager.Instance;
        game        = Game.Instance;
        if (open)
        {
            open = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        int riftDestroyed = 0;
        if (gameManager)
        {
            riftDestroyed = gameManager.m_RiftRemaining;
            if(ExitSign)
            ExitSign.text = string.Format("Rift Remaining {0}", riftDestroyed);
        }

        if(riftDestroyed <=0)
        {
            open = true;
        }

        if (open)
        {
            if (AudioManager.Instance)
            {
                AudioManager.Instance.PlaySoundSFX(Constants.Enemy_TimeRift_Close);
            }
            gameObject.SetActive(false);
        }
	}
}
