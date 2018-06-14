using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArms : Destroyable {

    public override void SetMaxHealth()
    {
        MaxHealth = GameSettings.BossHandsHealth;
    }
}
