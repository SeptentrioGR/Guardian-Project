using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    float force = 3;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(Constants.PlayerTag))
        {
     
            IDamagable damagable = collision.GetComponent<IDamagable>();
            Character character = collision.GetComponent<Character>();
            if (damagable != null && character.m_Alive)
            {
                damagable.TakeDamage(1);
                Debug.Log(gameObject.name + " Deal 1 Damage to " + character.gameObject.name);
            }
            ForcePush(collision);
        }
    }

    public void ForcePush(Collider2D collision)
    {
        var magnitude = 500;

        var force = transform.position - collision.transform.position;

        force.Normalize();
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-force * magnitude);
    }
}
