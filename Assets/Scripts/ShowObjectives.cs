using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowObjectives : MonoBehaviour {
    public Text ObjectiveText;
    public float alpha;

	void Start () {
        StartCoroutine(ShowObjective());
	}
	
	// Update is called once per frame
	void Update () {
        Color c = ObjectiveText.color;
        c.a = alpha;
        ObjectiveText.color = c; 
    }

    IEnumerator ShowObjective()
    {
        while (alpha < 1)
        {
            alpha+= Time.deltaTime;
             yield return null;
        }
        yield return new WaitForSeconds(2);
        while (alpha > 0)
        {
            alpha -= Time.deltaTime;
            yield return null;
        }
    }
}
