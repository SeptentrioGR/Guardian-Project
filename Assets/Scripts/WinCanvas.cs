using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCanvas : MonoBehaviour {
    public GameObject WinText;
    public GameObject StoryGameObject;
    public GameObject ResultsGameObject;
    public Animator animator;
    public GameObject ContinueButton;

    public void PlayUISound()
    {
        if (AudioManager.Instance)
            AudioManager.Instance.PlaySoundSFX(Constants.GUI_Select);
    }

    void Start()
    {
        if (AudioManager.Instance)
            AudioManager.Instance.SetMusic(Constants.MainThemeName);
        StartCoroutine(PlayWinScreen());
        ContinueButton.SetActive(false);
    }

    public void Continue()
    {
        PlayUISound();
        StartCoroutine(PlayResults());
    }

    IEnumerator PlayWinScreen()
    {
        WinText.SetActive(true);
        StoryGameObject.SetActive(true);
        animator.SetTrigger("Story");
        yield return new WaitForSeconds(8);
        ContinueButton.SetActive(true);

    }

    IEnumerator PlayResults()
    {
        ContinueButton.SetActive(false);
        WinText.SetActive(false);
        animator.SetTrigger("Results");
        ResultsGameObject.SetActive(true);
        yield return new WaitForSeconds(4.10f);
        StoryGameObject.SetActive(false);
    }

    public void QuitGame()
    {
        SceneLoader.Instance.LoadLevel("Main_Menu");
        GameManager.Instance.GotDamaged = 0;
        GameManager.Instance.Died = 0;
        GameManager.Instance.EnemyKilled = 0;
    }
}
