using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayerHere : MonoBehaviour {
    private Transform m_Target;

    public void TeleportHere()
    {
        if (AudioManager.Instance)
            AudioManager.Instance.PlaySoundSFX(Constants.PlayerTeleportIn);
        m_Target.position = transform.position;
    }

    void Awake () 
    {
        m_Target = GameObject.FindGameObjectWithTag("Player").transform;


	}

}
