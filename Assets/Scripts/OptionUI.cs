using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour {
    public GameObject Panel;
    public Slider VolumeSlider;

	// Use this for initialization
	void Start () {
        if (AudioManager.Instance)
        {
            VolumeSlider.value = AudioManager.Instance.GetMusicVolume();
        }
        VolumeSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

    }

    public void HidePanel()
    {
        if (AudioManager.Instance)
        {
            AudioManager.Instance.PlaySoundSFX(Constants.GUI_Close);
        }
        Panel.SetActive(false);
    }
    public void ShowPanel()
    {
        if (AudioManager.Instance)
        {
            AudioManager.Instance.PlaySoundSFX(Constants.GUI_Open);
        }
        Panel.SetActive(true);
    }
	
    public void ValueChangeCheck()
    {
        if (AudioManager.Instance)
        {
            AudioManager.Instance.PlaySoundSFX(Constants.GUI_Select);
        }
        AudioManager.Instance.UpdateVolume(VolumeSlider.value);
    }

}
