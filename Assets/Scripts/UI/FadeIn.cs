using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

	void Start ()
    {
        StartCoroutine(FadeTextToFullAlpha(0.1f, GetComponent<Text>()));
        StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text>()));
    }
	
    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        yield return new WaitForSeconds(61);
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
