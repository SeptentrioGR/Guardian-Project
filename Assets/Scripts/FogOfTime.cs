using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogOfTime : MonoBehaviour
{
    private GameObject Target;
    public float timer;
    public float delay;
    public bool startTimer = false;
    public float speed;
    public GameObject FadeBlindEffect;
    public bool isMoving = false;
    private Vector3 startingPos;

    private AudioSource source;

    void Awake()
    {
        //InvokeRepeating("Move", 0, Random.Range(2, 4));
        startingPos = transform.position;
        Target = GameObject.FindGameObjectWithTag("Player");
    }
    public void StopMoving()
    {
        transform.position = startingPos;
        isMoving = false;
    }
    public void StartMoving()
    {
        transform.position = startingPos;
        isMoving = true;
    }

    void Update()
    {
        if (!isMoving)
        {
            return;
        }

        if (startTimer)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Color c = FadeBlindEffect.GetComponent<Image>().color;
                c.a += 0.1f;
                FadeBlindEffect.GetComponent<Image>().color = c;

                if(c.a >= 1)
                {
                    IDamagable damagable = Target.GetComponent<IDamagable>();
                    Character character = Target.GetComponent<Character>();
                    if (damagable != null && character.m_Alive)
                    {
                        damagable.TakeDamage(1);
                    }
                }
            }
        }

        Move();
    }

    public void Move()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            startTimer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            startTimer = false;
            timer = delay;
            Color c = FadeBlindEffect.GetComponent<Image>().color;
            c.a = 0;
            FadeBlindEffect.GetComponent<Image>().color = c;
        }
    }
}
