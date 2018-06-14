using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, IDamagable
{
    public float MaxHealth;
    private float CurrentHealth;
    private AudioSource source;

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
    public void TakeDamage(int ammount)
    {
        CurrentHealth--;
        if (CurrentHealth < 0)
        {
            if (AudioManager.Instance)
            {
                AudioManager.Instance.PlaySoundSFX(Constants.PlayerBoxDestroy);
            }
            CurrentHealth = 0;
            Destroy();
        }
    }
}


