using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    void OnCollect(Character user);
}

public class Item : MonoBehaviour, ICollectable
{

    public virtual void OnCollect(Character user)
    {
        if (AudioManager.Instance)
            AudioManager.Instance.PlaySoundSFX(Constants.PlayerHealthPickup);
        Debug.Log("Collected by " + user.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Constants.PlayerTag)
        {
            OnCollect(collision.GetComponent<Character>());
        }
    }
}
