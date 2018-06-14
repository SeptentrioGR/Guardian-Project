using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {
    public Character m_Character;
    public Slider m_Slider;
    public Image m_HealthImage;
    public float m_HealthPresentage;

    void Start () {
        m_Slider.maxValue = m_Character.m_CurrentHealth;
    }
	
	void Update () {
        if (m_Character)
        {
            m_Slider.value = m_Character.m_CurrentHealth;
        }
        m_HealthImage.color = Color.Lerp(Color.red, Color.green, m_Slider.value / m_Slider.maxValue);

    }
}
