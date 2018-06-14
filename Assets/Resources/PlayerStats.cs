using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Guardian", menuName = "CharacterStat", order = 1)]
public class CharacterStat : ScriptableObject {
    public int m_MaxHealth;
    public int m_CurrentHealth;
}
