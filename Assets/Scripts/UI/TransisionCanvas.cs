using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransisionCanvas : MonoBehaviour{
    public static TransisionCanvas Instance { get; set; }


    public Animator m_Animator;
    public static string FADEINSTRINGKEY = "FadeIn";
    public static string FADEOUTSTRINGKEY = "FadeOut";

    public void FadeIn()
    {
        m_Animator.SetTrigger(FADEINSTRINGKEY);
    }

    public void FadeOut()
    {
        m_Animator.SetTrigger(FADEOUTSTRINGKEY);
    }

    public IEnumerator FadeScreen(float delay)
    {
        m_Animator.SetTrigger(FADEINSTRINGKEY);
        yield return new WaitForSeconds(delay);
        m_Animator.SetTrigger(FADEOUTSTRINGKEY);
    }

	void Awake () {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
