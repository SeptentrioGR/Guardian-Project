using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    public static SpeechBubble Instance;
    public bool SayingSomething = false;
    public GameObject SpeechBubbleGO;
    public Text SpeechBubbleText;
    private Coroutine SpeechBubbleCoroutine;
    private bool DontSayAnythingElse;

    private void Awake()
    {
        SpeechBubbleGO.SetActive(false);
        Instance = this;
    }

    public void BlockToSaySomethingNew(bool block)
    {
        DontSayAnythingElse = block;
    }

    public void Speek(string message, float ttl, bool force = true)
    {
        if (DontSayAnythingElse && SayingSomething)
        {
            return;
        }

        Stop();

        SpeechBubbleText.text = message;
        if (!SayingSomething)
        {
            SayingSomething = true;
            SpeechBubbleCoroutine = StartCoroutine(SpeekCoroutine(ttl));
        }
    }

    public void Stop()
    {
        if (DontSayAnythingElse)
        {
            return;
        }

        SayingSomething = false;
        SpeechBubbleGO.SetActive(false);
        if (SpeechBubbleCoroutine != null)
        {
            StopCoroutine(SpeechBubbleCoroutine);
            SpeechBubbleCoroutine = null;
        }
    }

    IEnumerator SpeekCoroutine(float ttl)
    {
        SpeechBubbleGO.SetActive(true);
        yield return new WaitForSeconds(ttl);
        SpeechBubbleGO.SetActive(false);
        yield return new WaitForSeconds(2f);
        SayingSomething = false;
    }

}
