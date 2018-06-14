using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlatformController : MonoBehaviour
{
    public ParticleSystem HitGroundSFX;

    private float horizontal;
    private float vertical;

    private SpriteRenderer spriteRenderer;
    private Animator m_Animator;
    private Rigidbody2D rb;

    [SerializeField] private float speed;
    [SerializeField] private bool Jumped;
    [SerializeField] private float forceJump;
    private int timeJumped = 0;

    private bool grounded = false;
    public Transform groundCheck;
    [SerializeField] private float groundRadius = 0.2f;
    [SerializeField] private LayerMask whatIsGround;
    private bool doubleJump;

    [SerializeField] private bool PlayerHasControl = false;
    private bool Shooting = false;
    public int FaceDirection = 1;
    public bool Walking;
    private AudioSource source;
    private bool HitGroundFirstTime = true;


    void Start()
    {
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        m_Animator = GetComponentInChildren<Animator>();
        Invoke("GainControl", 1f);
    }

    void Update()
    {

        m_Animator.SetBool(Constants.PlayerFireAnimationString, Shooting);
        m_Animator.SetBool(Constants.PlayerJumpAnimationString, !grounded);
        m_Animator.SetFloat(Constants.PlayerWalkingAnimationString, Mathf.Abs(horizontal));
        m_Animator.SetBool(Constants.PlayerDeathAnimationString, GetComponent<Guardian>().m_Alive);

        if (!GetComponent<Guardian>().m_Alive)
        {
            return;
        }


        Shooting = CrossPlatformInputManager.GetButton(Constants.m_FireButtonString);

        if(!Jumped)
        Jumped = CrossPlatformInputManager.GetButtonDown(Constants.JumpButtonString);



    }

    void FixedUpdate()
    {

        if (!PlayerHasControl || !GetComponent<Guardian>().m_Alive)
        {
            return;
        }

        horizontal = Controls.GetHorizontalAxis();
        vertical = Controls.GetVerticalAxis();

        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //if (grounded)
        //{
        //    //Old Effect Doesn't work right now as Intented
        //    //if (HitGroundFirstTime)
        //    //{
        //    //    HitGroundFirstTime = false;
        //    //    HitGroundSFX.Play();
        //    //}
        //    doubleJump = false;

        //}
        grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
                doubleJump = false;
            }
        }

        Movement(horizontal, Jumped);
        Jumped = false;
    }

    void Movement(float move, bool Jumped)
    {
        if (Jumped)
        {
            float modifiedJumpForce = forceJump;
            if (!grounded && doubleJump)
            {
                return;
            }


            if (AudioManager.Instance)
                AudioManager.Instance.PlaySoundSFX(source, Constants.PlayerJump);

            if (!grounded && !doubleJump)
            {
                doubleJump = true;
                if (AudioManager.Instance)
                    AudioManager.Instance.PlaySoundSFX(source, Constants.PlayerJumpDouble);
            }
            //Debug.Log("modifiedJumpForce" + modifiedJumpForce);
            rb.velocity = Vector2.up + new Vector2(0, modifiedJumpForce);
        }

        Flip();

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }




    private void Flip()
    {
        if (horizontal > 0)
        {
            FaceDirection = -1;
        }
        else if (horizontal < 0)
        {
            FaceDirection = 1;
        }
        transform.localScale = new Vector3(FaceDirection, 1, 1);
    }

    public int GetFaceDirection()
    {
        return FaceDirection;
    }

    public void GainControl()
    {
        GainPlayerControl();
    }

    public void GainPlayerControl(bool value = true)
    {
        if (!PlayerHasControl)
            PlayerHasControl = value;
    }

}
