using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Patrol
{
    public override void Initialize()
    {
        base.Initialize();
        m_CurrentHealth = GameSettings.SoldierMaxHealth;
    }
}
