using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShoot : MonoBehaviour
{
    public Character m_Character;
    public GameObject m_Prefab;
    public float m_FireRate;
    public float m_NextFire;
    private Vector3 diff;
    public float m_bulletSpeed;
    public Transform m_Gun;
    private AudioSource source;

    void Start()
    {
        source = GetComponentInParent<AudioSource>();
    }


    void Update()
    {
        if (!m_Character.m_Alive)
        {
            return;
        }

        if (CrossPlatformInputManager.GetButton(Constants.Mobile2ButtonString))
        {
            if (Time.time > m_NextFire)
            {
                m_NextFire = Time.time + m_FireRate;

                //Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                //direction.Normalize();

                GameObject bullet = Instantiate(m_Prefab, transform.position, Quaternion.identity);
                int FaceDirection = GetComponentInParent<PlatformController>().GetFaceDirection();
                Vector3 shootDirection = FaceDirection * Vector3.left;

                bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * m_bulletSpeed;
                //bullet.transform.eulerAngles = transform.forward;
                if (AudioManager.Instance)
                    AudioManager.Instance.PlaySoundSFX(source, Constants.PlayerLaserShot);
            }
        }



    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.localPosition, diff);
    }


}
