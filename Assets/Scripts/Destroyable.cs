using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour,IDamagable{

    [HideInInspector] public string HitAnimationString = "Hit";
    public  bool Destroyed;
    public float MaxHealth;
    private float CurrentHealth;
    private Animator animator;


    public void TakeDamage(int ammount)
    {
        animator.SetTrigger(HitAnimationString);
        CurrentHealth--;
        if (AudioManager.Instance)
        {
            AudioManager.Instance.PlaySoundSFX(Constants.EnemyHurt);
        }
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
            Destroy();
            if (AudioManager.Instance)
            {
                AudioManager.Instance.PlaySoundSFX(Constants.EnemyDeath);
            }
        }
    }

    public virtual void SetMaxHealth()
    {
        MaxHealth = GameSettings.BossHandsHealth;
    }

    void Start () {
        animator = GetComponent<Animator>();
        Destroyed = false;
        SetMaxHealth();
        CurrentHealth = MaxHealth;
    }
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            Character character = collision.GetComponent<Character>();
            if (character != null && character.m_Alive)
            {
                character.TakeDamage(1);
            }
        }

        if (collision.tag == "Player")
        {
            IDamagable damagable = collision.GetComponent<IDamagable>();
            Character character = collision.GetComponent<Character>();
            if (damagable != null && character.m_Alive)
            {
                damagable.TakeDamage(1);
            }
        }
    }

    public virtual void Destroy()
    {
        Destroyed = true;
        gameObject.SetActive(false);
    }
}
