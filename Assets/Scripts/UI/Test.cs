using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {
    [SerializeField]
    float WaitTime;
	// Use this for initialization
	void Start () {
        StartCoroutine(FadeTextToZeroAlpha(WaitTime, GetComponent<Text>()));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        yield return new WaitForSeconds(5);
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
