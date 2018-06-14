using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarWidget : MonoBehaviour
{
    public Character m_Character;
    //public Slider m_Slider;
    //public Image m_HealthImage;
    //public float m_HealthPresentage;

    public GameObject LifeElement;
    public GameObject LifeHolder;
    public GameObject[] Lifes;


    void Start()
    {
        // m_Slider.maxValue = m_Character.m_CurrentHealth;
        Lifes = new GameObject[(int)m_Character.m_MaxHealth];
        for (int i = 0; i < Lifes.Length; i++)
        {
            Lifes[i] = Instantiate(LifeElement, LifeHolder.transform, false);
            Lifes[i].GetComponent<LifeElement>().LifeLost(true);
        }


    }

    void Update()
    {
        //if (m_Character)
        //{
        //    m_Slider.value = m_Character.m_CurrentHealth;
        //}
        //m_HealthImage.color = Color.Lerp(Color.red, Color.green, m_Slider.value / m_Slider.maxValue);
        if (m_Character.m_CurrentHealth > 0)
        {
            Lifes[m_Character.m_CurrentHealth - 1].GetComponent<LifeElement>().LifeLost(true);
        }

        if (m_Character.m_CurrentHealth < Lifes.Length)
        {
            Lifes[m_Character.m_CurrentHealth].GetComponent<LifeElement>().LifeLost(false);
        }
    }
}
