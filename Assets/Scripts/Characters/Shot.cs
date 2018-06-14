using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject m_Target;
    public GameObject m_Prefab;
    public float m_FireRate;
    public float m_NextFire;
    public float m_bulletSpeed;
    private Enemy EnemyScript;

    void Start()
    {
        m_Target = GameObject.FindGameObjectWithTag("Player");
        EnemyScript = GetComponent<Enemy>();
    }

    void Update()
    {
        EnemyScript.isAttacking = false;
        if (Time.time > m_NextFire)
        {
            EnemyScript.isAttacking = true;
            m_NextFire = Time.time + m_FireRate;

            Vector2 direction = Camera.main.WorldToScreenPoint(m_Target.transform.position) - Camera.main.WorldToScreenPoint(transform.position);
            direction.Normalize();

            GameObject bullet = Instantiate(m_Prefab, transform.position, Quaternion.identity);
            //bullet.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * GetComponent<Enemy>().GetDirection() * 500);
            //bullet.GetComponent<Rigidbody2D>().velocity = direction * m_bulletSpeed;
            if (AudioManager.Instance)
                AudioManager.Instance.PlaySoundSFX(Constants.EnemyLaserShot);

        }
    }
}
