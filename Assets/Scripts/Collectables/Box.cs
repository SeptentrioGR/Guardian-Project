using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamagable
{
    public GameObject[] Collectables;
    public float MaxHealth;
    private float CurrentHealth;

    public void Destroy()
    {
        SpawnItem();
        if (AudioManager.Instance)
            AudioManager.Instance.PlaySoundSFX(Constants.PlayerBoxDestroy);
        Destroy(gameObject);
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;

    }

    public void SpawnItem()
    {
        int change = Random.Range(0, 100);
        if (change < 50)
        {
            Instantiate(Collectables[Random.Range(0, Collectables.Length)], transform.position, Quaternion.identity);
        }
    }

    public void TakeDamage(int ammount)
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.GotDamaged++;
        }
        CurrentHealth--;
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
            if (GameManager.Instance)
            {
                GameManager.Instance.Died++;
            }
            Destroy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player/Melee" || collision.tag == "Player/Projectile")
        {
            IDamagable damagable = collision.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(1);
            }
        }
    }
}
