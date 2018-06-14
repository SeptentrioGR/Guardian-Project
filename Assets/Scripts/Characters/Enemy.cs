using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public Animator animator;
    public GameObject Target;
    public SpriteRenderer m_SpriteRenderer;
    public int m_Direction = 1;
    private Shot m_ShotScript;
    private AudioSource source;

    [HideInInspector] public bool isChasing;
    [HideInInspector] public bool isAttacking;
    [HideInInspector] public bool isWalking;
    [HideInInspector] public bool DealDamage;
    private bool Died = false;

    public override void TakeDamage(int ammount)
    {
        base.TakeDamage(ammount);
        if (AudioManager.Instance)
        {
            AudioManager.Instance.PlaySoundSFX(Constants.EnemyHurt);
        }
    }

    public void Animate(bool isWalking,bool isAttacking,bool isChasing)
    {
        SetAnimation(Constants.IdleAnimationString, !isWalking && !isAttacking && !isChasing);
        SetAnimation(Constants.WalkingAnimationString, isWalking);
        SetAnimation(Constants.HitAnimationString, TookDamaged);
        SetAnimation(Constants.AttackAnimationString, isAttacking);
    }

    void Awake()
    {
        m_Alive = true;
        Target = GameObject.Find("TimeGuardian");
        Initialize();
    }

    public virtual void Initialize()
    {
        m_ShotScript = GetComponent<Shot>();
    }

    void Update()
    {
        SetAnimation(Constants.DeathAnimationString, !m_Alive);
        if (m_Alive)
        {
            OnHit();
            Movement();
	//		AudioManager.Instance.PlaySoundSFX(source, Constants.EnemyHurt);
        }
        else if (!m_Alive && !Died)
        {
            Death();
            if (AudioManager.Instance)
            {
                AudioManager.Instance.PlaySoundSFX(Constants.EnemyDeath);
            }
        }
    }

    public override void Death()
    {
        base.Death();
        Died = true;
        AnimatorStateInfo currInfo = animator.GetCurrentAnimatorStateInfo(0);
        Destroy(gameObject, currInfo.length + 0.5f);
    }

    public virtual void TurnAtPlayerLocation()
    {
        if (Target)
        {
            float dist = Vector2.Distance(transform.position, Target.transform.position);
            Vector3 diff = Target.transform.position - transform.position;
            diff.Normalize();
            if (diff.x > 0)
            {
                m_Direction = -1;
            }
            else
            {
                m_Direction = 1;
            }
            transform.localScale = new Vector3(m_Direction, 1, 1);
        }
        else
        {
            m_ShotScript.enabled = false;
        }
    }

    public virtual void Shot()
    {
        if (Target)
        {
            float dist = Vector2.Distance(transform.position, Target.transform.position);
            m_ShotScript.enabled = true;
            if (dist > 5)
            {
                m_ShotScript.enabled = false;
            }
        }
        else
        {
            m_ShotScript.enabled = false;
        }
    }

    public virtual void Movement()
    {

    }

    public int GetDirection()
    {
        return m_Direction;
    }

    public void SetAnimation(string ID, bool Value)
    {
        animator.SetBool(ID, Value);
    }

    public void GetPlayerTarget()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        Target = target;
    }

    public bool IsCloseBy(GameObject Target, float max)
    {
        float dist = Vector3.Distance(transform.position, Target.transform.position);

        if (dist < max)
        {
            return true;
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (m_Alive && collision.gameObject.tag == Constants.PlayerTag)
        {
            GameObject InteractedGameObject = collision.gameObject;
            IDamagable damagable = InteractedGameObject.GetComponent<IDamagable>();
            Character character = InteractedGameObject.GetComponent<Character>();
            if (damagable != null && character.m_Alive)
            {
                damagable.TakeDamage(1);
            }
        }
    }
}
