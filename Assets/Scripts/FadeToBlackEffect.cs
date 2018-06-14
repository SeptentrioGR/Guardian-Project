using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class FadeToBlackEffect : MonoBehaviour {
    public Image BG;
    public float Alpha;

    private void Reset()
    {
        BG = GetComponent<Image>();
    }

    private void AWake()
    {
        BG = GetComponent<Image>();
    }

    private void OnEnable()
    {
        Color c = BG.color;
        c.a = 0;
        BG.color = c;

        StartCoroutine(FadeBlackBG());
    }

    IEnumerator FadeBlackBG()
    {
        while (BG.color.a < 1)
        {
            Color c = BG.color;
            c.a += Alpha * Time.deltaTime;
            BG.color = c;
            yield return null;
        }

    }
}
