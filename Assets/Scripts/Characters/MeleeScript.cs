using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour
{
    public Character User;
    private string MeleeAnimationString = "Melee";
    public Animator Animator;
    private bool MeleeAttack;
    private BoxCollider2D boxCollider2D;
    private AudioSource source;

    public float meleeDelay;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if (Input.GetKeyDown(KeyCode.F) && !MeleeAttack)
        {
            StartCoroutine(MeleeScriptDelay());
            if (AudioManager.Instance)
                AudioManager.Instance.PlaySoundSFX(Constants.PlayerMelee);
        }

        Animator.SetBool(MeleeAnimationString, MeleeAttack);
    }

    IEnumerator MeleeScriptDelay()
    {
        MeleeAttack = true;
        boxCollider2D.enabled = true;
        yield return new WaitForSeconds(meleeDelay);
        boxCollider2D.enabled = false;
        MeleeAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (User.m_Alive)
        {
            if (collision.tag == "Enemy" && !collision.GetComponent<Boss>() && !collision.GetComponent<TimeRift>())
            {
                Debug.Log("Attacked" + collision.gameObject);
                IDamagable damagable = collision.GetComponent<IDamagable>();
                if (damagable != null && collision.GetComponent<Character>().m_Alive)
                {
                    damagable.TakeDamage(1);
                    collision.GetComponent<Rigidbody2D>().AddForce(transform.right * 100);
                }
            }
        }
    }
}
