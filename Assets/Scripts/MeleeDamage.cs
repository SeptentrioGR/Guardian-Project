using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour {
    public Character user;
    private void Start()
    {
        user = GetComponentInParent<Character>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!user.m_Alive)
        {
            return;
        }
        if(collision.tag == "Player")
        {
            collision.GetComponent<IDamagable>().TakeDamage(1);
            ForcePush(collision);
        }
    }


    public void ForcePush(Collider2D collision)
    {
        var magnitude = 1000;

        var force = transform.position - collision.transform.position;

        force.Normalize();
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-force * magnitude);
    }
}
