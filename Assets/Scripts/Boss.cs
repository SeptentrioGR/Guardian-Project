using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public Destroyable[] damagables;
    private bool exposed;
    public Vector3[] Positions;
    private int currentPos;

    private bool AttackingLeft;
    private bool AttackingRight;
    public Rigidbody2D rb2d;
    private bool Died;
    private AudioSource source;


    public float moveSpeed;

    public override void Initialize()
    {
        m_CurrentHealth = GameSettings.BossHealth;
    }

    void Start()
    {
        exposed = false;
        StartCoroutine(ChangeDirection());
        source = GetComponentInParent<AudioSource>();
    }

    public override void Death()
    {
        if (!Died)
        {
            Died = true;
            Destroy(gameObject, 2f);
            if (AudioManager.Instance)
                AudioManager.Instance.PlaySoundSFX(Constants.BossDeath);
            SetAnimation(Constants.DeathAnimationString, true);
            Game.Instance.GameFinished();
        }

    }

    public override void Movement()
    {

        animator.SetBool(Constants.IdleAnimationString, !AttackingLeft && !AttackingRight);
        animator.SetBool(Constants.BossLeftAttack, AttackingLeft);
        animator.SetBool(Constants.BossRightAttack, AttackingRight);
        animator.SetBool(Constants.HitAnimationString, TookDamaged);
        Vector3 vel = rb2d.velocity;
        transform.position =
            Vector3.SmoothDamp(
                transform.position,
                Positions[currentPos], ref vel, moveSpeed * Time.deltaTime);
        exposed = damagables[0].Destroyed && damagables[1].Destroyed;
    }

    public override void TakeDamage(int ammount)
    {
        if (exposed)
        {
            base.TakeDamage(ammount);
            if (AudioManager.Instance)
                AudioManager.Instance.PlaySoundSFX(Constants.BossHurt);
        }

    }
    public int GetNotDamagablePart()
    {
        for (int i = 0; i < damagables.Length; i++)
        {

            if (!damagables[i].Destroyed)
            {
                return i;
            }
        }
        return 2;
    }

    IEnumerator ChangeDirection()
    {
        while (m_Alive)
        {
            AttackingLeft = false;
            AttackingRight = false;

            if (exposed)
            {
                ShootProjectiles();
            }

            yield return new WaitForSeconds(4);

            if (!exposed)
            {
                currentPos = Random.Range(0, 2);

                if (damagables[currentPos].Destroyed)
                {
                    currentPos = GetNotDamagablePart();
                }

                if (currentPos == 0 || currentPos == 1)
                {
                    if (currentPos == 0)
                    {
                        AttackingLeft = true;
                        if (AudioManager.Instance)
                            AudioManager.Instance.PlaySoundSFX(Constants.BossAttack);

                    }
                    else if (currentPos == 1)
                    {
                        AttackingRight = true;
                        if (AudioManager.Instance)
                            AudioManager.Instance.PlaySoundSFX(Constants.BossAttack);

                    }


                    yield return new WaitForSeconds(2);
                    currentPos = 2;
                    AttackingLeft = false;
                    AttackingRight = false;
                }
            }
            else
            {
                currentPos = 3;
                yield return new WaitForSeconds(2);
                currentPos = 0;
            }
        }
    }

    public GameObject ProjectilePrefab;

    public void ShootProjectiles()
    {
        for (int i = 0; i < 16; i++)
        {

            Instantiate(ProjectilePrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, i * 25f)));
        }
    }
}


