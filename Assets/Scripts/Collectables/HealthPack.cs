using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : Item
{
    private AudioSource source;
    public override void OnCollect(Character user)

    {
        Debug.Log("Collected by " + user.name);
        user.Heal();
        Destroy(gameObject);
    }
}
