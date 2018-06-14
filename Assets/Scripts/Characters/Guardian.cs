using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : Character
{
    public static string PlayerHurtString = "Guardian_SFX_PlayerHurt_v1_SB";
    public static string PlayerDeathString = "Guardian_SFX_PlayerDeath_v1_SB";
    public static string PlayerDoubleJumpString = "Guardian_SFX_PlayerJumpDouble_v1_SB";
    public static string PlayerJumpingString = "Guardian_SFX_PlayerJumpSingle_v1_SB";
    public static string PlayerShotString = "Guardian_SFX_PlayerLaserShot_v3_SB";
    private AudioSource source;

    private void Awake()
    {
      
        if (GameManager.Instance)
        {
            if (GameManager.Instance.GetPlayerStat() == 0)
            {
                GameManager.Instance.SetPlayerStat(m_CurrentHealth, m_MaxHealth);
            }
            else
            {
                m_CurrentHealth = GameManager.Instance.GetPlayerStat();
            }
         
        }
        else {
            m_CurrentHealth = GameSettings.PlayerMaxHealth;
        }
    }

    void Start()
    {
        Timer = delayAfterAttack;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        OnHit();
    }

    public override void TakeDamage(int ammount)
    {
        base.TakeDamage(ammount);
        if (AudioManager.Instance)
            AudioManager.Instance.PlaySoundSFX(source, Constants.PlayerHurt);
        if (GameManager.Instance)
        {
            GameManager.Instance.SetPlayerStat(m_CurrentHealth, m_MaxHealth);
        }
    }
    public override void Death()
    {
        base.Death();
        if (AudioManager.Instance)
            AudioManager.Instance.PlaySoundSFX(source, Constants.PlayerDeath);
        if (GameManager.Instance)
        {
            GameManager.Instance.SetPlayerStat(m_CurrentHealth, m_MaxHealth);
        }
    }


}
