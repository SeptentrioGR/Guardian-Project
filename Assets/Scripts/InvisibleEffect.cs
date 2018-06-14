using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleEffect : MonoBehaviour
{
    public Character m_User;
    public SpriteRenderer[] m_Renderer;
    public GameObject m_Target;
    public float maxDist;
    public GameObject HealthBarUI;

    void Start()
    {
        m_Target = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Invisible());
    }

    IEnumerator Invisible()
    {
        while (m_User.m_Alive)
        {
            float dist = Vector3.Distance(transform.position, m_Target.transform.position);
            foreach (var item in m_Renderer)
            {
                item.enabled = dist < maxDist;
                HealthBarUI.SetActive(item.enabled);

            }
            yield return null;
        }
    }
}
