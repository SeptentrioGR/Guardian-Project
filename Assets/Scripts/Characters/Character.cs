using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Character : MonoBehaviour, IDamagable
{
    public bool TookDamaged = false;
    public SpriteRenderer spriteRenderer;
    public Color HitColor = Color.red;
    public Color normalHit = Color.white;
    public delegate void OnCharacterDeath();
    public event OnCharacterDeath OnCharacterDeathHandled;

    public bool m_Alive = false;
    public int m_CurrentHealth;
    public int m_MaxHealth;
    public float Timer = 0;
    public float delayAfterAttack = .25f;


    public virtual void OnHit()
    {   
        if (TookDamaged && m_Alive)
        {
            spriteRenderer.color = HitColor;
            Timer -= Time.deltaTime;
        
            if (Timer < 0)
            {
                Timer = delayAfterAttack;
                TookDamaged = false;
                spriteRenderer.color = normalHit;
            }
        }
    }

    public virtual void Death()
    {
        if (OnCharacterDeathHandled != null)
        {
            OnCharacterDeathHandled();
        }
    }

    public virtual void TakeDamage(int ammount)
    {
        if (!TookDamaged)
        {
            TookDamaged = true;
            m_CurrentHealth -= ammount;
            if (m_CurrentHealth <= 0)
            {
                m_CurrentHealth = 0;
                m_Alive = false;
            }
        }
    }

    public void Heal()
    {
        m_CurrentHealth++;
        if(m_CurrentHealth >= m_MaxHealth)
        {
            m_CurrentHealth = m_MaxHealth;
        }
    }
}
