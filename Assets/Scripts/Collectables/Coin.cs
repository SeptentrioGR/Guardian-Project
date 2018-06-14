using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public override void OnCollect(Character user)
    {
        base.OnCollect(user);
        if (Game.Instance)
        Game.Instance.CollectStart();
        Destroy(gameObject);
    }
}
