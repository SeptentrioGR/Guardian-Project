using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform Target;
    public string m_TargetTag;
    public float m_speed;
    private float angle;
    public float Angle
    {
        get; set;
    }

    private void Start()
    {
        Initialize();
    }

    public void Update()
    {
        Movement();
        Vector2 camPos = Camera.main.WorldToViewportPoint(transform.position);
        if (camPos.x > 1 || camPos.x < 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Initialize()
    {
        Target = GameObject.FindGameObjectWithTag(m_TargetTag).transform;
        Vector3 dir = Target.position - transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        GetComponent<Rigidbody2D>().velocity = dir * m_speed;
    }

    public virtual void Movement()
    {
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == m_TargetTag)
        {
            IDamagable damagable = collision.GetComponent<IDamagable>();
            Character character = collision.GetComponent<Character>();
            if (damagable != null && character != null)
            {
                damagable.TakeDamage(1);
            }
            Destroy(gameObject);
        }

        if (collision.tag == Constants.DestryoableTag)
        {
            IDamagable damagable = collision.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(1);
            }
            Destroy(gameObject);
        }

    }
}
