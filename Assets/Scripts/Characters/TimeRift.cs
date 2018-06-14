using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRift : Character, IInteractable
{
    public GameObject m_HealthBar;
    public GameObject target;
    public Vector3 m_Rotation;
    public GameObject m_Prefab;
    public GameObject m_EnemyPrefab;
    public bool m_Open = false;
    public float newSize = 0;

    public AudioSource source;
    private bool DeathSoundPlayed = false;
    public bool Damagable;
    public bool Interactable;

    public bool CanInteractWith
    {
        get
        {
            return Interactable;
        }

        set
        {
            Interactable = value;
        }
    }

    void Start()
    {
 
        source = GetComponent<AudioSource>();

        Damagable = false;
        Interactable = true;

        m_CurrentHealth = GameSettings.TimeRiftMaxHealth;

        if (Game.Instance)
            target = Game.Instance.GetPlayer();
    }

    public void StartRift()
    {
        if (AudioManager.Instance)
            AudioManager.Instance.PlaySoundSFX(source,
                Constants.Enemy_TimeRift_Open);
        StartCoroutine(Open());

    }
    void Update()
    {

        m_HealthBar.SetActive(Damagable);

        OnHit();
        Vector3 size = new Vector3(newSize, newSize, newSize);
        transform.localScale = size;
        transform.localScale = new Vector3(
            Mathf.Clamp(size.x, 0, 1),
            Mathf.Clamp(size.y, 0, 1),
            Mathf.Clamp(size.z, 0, 1));

        if (!m_Open)
        {
            return;
        }

        transform.localScale = Vector3.one;

        if (!m_Alive)
        {
            Death();
        }
        //m_Prefab.transform.Rotate(m_Rotation);
    }

    IEnumerator Open()
    {
        float timeSinceStart = Time.time;
        while (newSize < 1)
        {
            newSize = (Time.time - timeSinceStart) / 3;


            yield return null;
        }

        m_Open = true;
    }

    public override void TakeDamage(int ammount)
    {
        if (!m_Open || !Damagable)
            return;
        base.TakeDamage(ammount);
        if (m_CurrentHealth > 0 && m_CurrentHealth % 2 == 0)
        {
            //SpawnEnemy();
        }
    }
    public override void Death()
    {
        base.Death();
        if (AudioManager.Instance)
        {
            AudioManager.Instance.PlaySoundSFX(source, Constants.Enemy_TimeRift_Close);
            Destroy(gameObject);
        }

    }

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(m_EnemyPrefab, transform.position, Quaternion.identity);
        enemy.transform.SetParent(transform.parent);
        enemy.GetComponentInChildren<Rigidbody2D>().transform.position = transform.position - Vector3.right;
        Character character = enemy.GetComponent<Character>();
        if (character == null)
        {
            character = enemy.GetComponentInChildren<Character>();
        }
        character.OnCharacterDeathHandled += Game.Instance.OnEnemyDeath;
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    public void Action()
    {
        Interactable = false;
        Damagable = true;
        GenerateTowerOfPlatforms.Instance.Teleport(target, gameObject);
    }
}
