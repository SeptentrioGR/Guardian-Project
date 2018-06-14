using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterBullet : Projectile {
    Vector3 dir;
    public override void Initialize()
    {
        dir = transform.right - transform.position;
        Angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }

    public override void Movement()
    {
        transform.Translate(dir * m_speed);
    }

}
