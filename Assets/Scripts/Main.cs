using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        if (AudioManager.Instance)
            AudioManager.Instance.SetMusic(Constants.MainThemeName);
    }

    public void PlayUISound()
    {
        if (AudioManager.Instance)
            AudioManager.Instance.PlaySoundSFX(Constants.GUI_Select);
    }
}
