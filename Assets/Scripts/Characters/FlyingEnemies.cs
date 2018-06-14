using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemies : Enemy {

    private float RotateSpeed = 2.5f;
    private float Radius = 0.25f;

    private Vector2 _centre;
    private float _angle;


    public Transform m_SpawnPoints;
    public Shot ShotScript;

    public override void Initialize()
    {
        base.Initialize();
        m_CurrentHealth = GameSettings.FlyingEnemyMaxHealth;
    }

    private void Start()
    {
        _centre = transform.position;
        ShotScript = GetComponent<Shot>();
    }

    public override void Movement()
    {
        isWalking = false;
        isAttacking = false;
        isChasing = false;

        Animate(isWalking, isAttacking, isChasing);
        OnHit();
        TurnAtPlayerLocation();
        MoveAround();
    }

    public override void TurnAtPlayerLocation()
    {
        Vector3 dir = transform.position - Target.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if(angle > 60)
        {
            m_SpriteRenderer.flipX = true;
        }
        else if (angle < 60)
        {
            m_SpriteRenderer.flipX = false;
        }
      //  transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void MoveAround()
    {
        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
    }
}
