using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour {

    GameManager gameManager;

    public Text StarCollected;
    public Text EnemyKilledText;
    public Text GotDamaged;
    public Text Deaths;

    public void Initialize(GameManager gm)
    {
        gameManager = gm;
    }

    private void Awake()
    {
        Initialize(GameManager.Instance);
    }

    private void OnEnable()
    {
        if (gameManager)
        {
            StarCollected.text = TranslateIntToString("Star Collected : {0}", gameManager.StarCollected);
            EnemyKilledText.text = TranslateIntToString("Enemies Killed : {0}", gameManager.EnemyKilled);
            GotDamaged.text = TranslateIntToString("Got Damaged : {0}", gameManager.GotDamaged);
            Deaths.text = TranslateIntToString("Got Killed: {0}", gameManager.Died);

            StartCoroutine(FadeInText(.1f, StarCollected));
            StartCoroutine(FadeInText(.1f, EnemyKilledText));
            StartCoroutine(FadeInText(.1f, GotDamaged));
            StartCoroutine(FadeInText(.1f, Deaths));
        }
    }

    void Start () {
        if (gameManager)
        {
            StarCollected.text = TranslateIntToString("Star Collected : {0}", gameManager.StarCollected);
            EnemyKilledText.text = TranslateIntToString("Enemies Killed : {0}", gameManager.EnemyKilled);
            GotDamaged.text = TranslateIntToString("Got Damaged : {0}", gameManager.GotDamaged);
            Deaths.text = TranslateIntToString("Got Killed: {0}", gameManager.Died);

            StartCoroutine(FadeInText(.1f, StarCollected));
            StartCoroutine(FadeInText(.1f, EnemyKilledText));
            StartCoroutine(FadeInText(.1f, GotDamaged));
            StartCoroutine(FadeInText(.1f, Deaths));
        }
	}
	    
    public string TranslateIntToString(string text,int num)
    {
        return string.Format(text, num);
    }

    IEnumerator FadeInText(float t,Text i)
    {
        yield return new WaitForSeconds(61);
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
}
