using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Enemy
{
    private GameObject[] Waypoints;
    private int CurrentWaypoint;
    private int Direction;
    private int FaceDirection = 1;
    private Vector2 velocity = Vector2.zero;
    public LayerMask GroundLayer;
    public GameObject WaypointElement;
    public LayerMask Targets;
    public float DistancePatrol;
    public float speed;
    public float maxDist;
    public float LineOfSight;

    public GameObject[] CheckAvailableMovement;
    public bool CanMoveRight;
    public bool CanMoveLeft;
    private bool playerClose;

    private float dist;

    void Start()
    {
        Timer = delayAfterAttack;
        Target = GameObject.FindGameObjectWithTag("Player");
        GameObject waypointHolder = GameObject.Find("Waypoint");
        InvokeRepeating("SetRandomWaipoint", 1, 4f);
        Waypoints = new GameObject[3];
        int num = 1;
        GameObject wp;
        for (int i = 0; i < Waypoints.Length - 1; i++)
        {
            wp = Instantiate(WaypointElement, waypointHolder.transform, false);
            wp.transform.position = transform.position + num * (Vector3.right * DistancePatrol);
            num *= -1;
            Waypoints[i] = wp;
        }
        wp = Instantiate(WaypointElement, waypointHolder.transform, false);
        wp.transform.position = transform.position;
        Waypoints[Waypoints.Length - 1] = wp;
        CurrentWaypoint = Waypoints.Length - 1;
    }

    public override void Movement()
    {
        OnHit();
        Animate(isWalking, isAttacking, !isWalking || !isAttacking);

        isWalking = false;
        isAttacking = false;

        if (!m_Alive)
        {
            CapsuleCollider2D capsule2D = GetComponent<CapsuleCollider2D>();
            if (capsule2D.enabled)
            {
                capsule2D.enabled = m_Alive;
            }
        }

        CanMoveRight =
     Physics2D.OverlapCircle(CheckAvailableMovement[0].transform.position, 0.25f, GroundLayer);
        CanMoveLeft =
           Physics2D.OverlapCircle(CheckAvailableMovement[1].transform.position, .25f, GroundLayer);

        if (TookDamaged)
        {
            if (CanMoveLeft && GetDirection() < 0)
            {
                LineOfSight = 6;
            }
            else if (CanMoveRight && GetDirection() > 0)
            {
                LineOfSight = 6;
            }
        }

        Collider2D AttackingDistance = Physics2D.OverlapCircle(transform.position, LineOfSight, Targets);
        if (AttackingDistance && AttackingDistance.GetComponent<Character>().m_Alive)
        {
            TurnAtPlayerLocation();
            Chase(AttackingDistance.gameObject);
        }
        else
        {
            Target = Waypoints[CurrentWaypoint];
        }

        float dist = Vector3.Distance(transform.position, Target.transform.position);

        if (dist > maxDist)
        {
            if (!CanMoveLeft)
            {
                if(dist < 0)
                {
                    return;
                }
            }

            if (!CanMoveRight)
            {
                if (dist > 0)
                {
                    return;
                }
            }

            Vector2 diffrencePos = (Target.transform.position - transform.position).normalized;

            transform.position = Vector3.MoveTowards(transform.position, diffrencePos, speed * Time.deltaTime);
        }

    }

    public void Chase(GameObject Target)
    {
        isChasing = true;
        //Debug.Log("Target is on sight");
        TurnAtPlayerLocation();
        this.Target = Target;
        if (IsCloseBy(Target, .7f))
        {
            //Debug.Log("Target IS Close");
            isAttacking = true;
        }
    }

    public void SetRandomWaipoint()
    {
        int num = Random.Range(0, 100);
        if (num < 25)
        {
            Direction = 0;
        }
        else if (num > 25 && num < 75)
        {
            Direction = 1;
        }
        else if (num > 75)
        {
            Direction = 2;
        }

        CurrentWaypoint = Direction;
    }

    public void Attacked()
    {
        DealDamage = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, LineOfSight);
    }

}
