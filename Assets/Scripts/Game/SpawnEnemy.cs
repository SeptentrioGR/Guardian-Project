using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] m_Prefab;
    public GameObject m_TimeRiftPrefab;

    public GameObject m_TimeRift;
    public GameObject m_Enemy;

    public bool m_SpawnedSomething;
    public float m_Timer;
    public float m_Delay;

    public GameObject[] m_SpawnLocations;
    public Land[] ListOfLands;

    void Awake()
    {
        m_Timer = m_Delay;
        foreach (Land item in ListOfLands)
        {
            m_SpawnLocations = item.GetSpawnPoints();
        }
    }

    void Update()
    {
        if(Game.Instance.gameOver)
        return;

        if (m_Enemy == null && m_TimeRift == null && m_SpawnedSomething)
        {
            m_SpawnedSomething = false;
    
        }

        if (!m_SpawnedSomething)
        {
            m_Timer -= Time.deltaTime;
            if (m_Timer <= 0)
            {
               

                int num = Random.Range(1, 100);
                if (num > 75f)
                {
                    Land item = ListOfLands[Random.Range(0, ListOfLands.Length)];
                    m_SpawnLocations = item.GetSpawnPoints();
                    m_TimeRift = Instantiate(m_TimeRiftPrefab,
                        m_SpawnLocations[Random.Range(0, m_SpawnLocations.Length)].transform.position, 
                        Quaternion.identity);
                    m_TimeRift.transform.SetParent(transform);
                    m_TimeRift.GetComponent<Character>().OnCharacterDeathHandled += OnRiftDestroyed;
                    m_SpawnedSomething = true;

                    m_Timer = m_Delay;
                }

                if (num < 20)
                {
                    Land item = ListOfLands[Random.Range(0, ListOfLands.Length)];
                    m_SpawnLocations = item.GetSpawnPoints();
                    m_Enemy = Instantiate(m_Prefab[Random.Range(0, m_Prefab.Length)], m_SpawnLocations[Random.Range(0, m_SpawnLocations.Length)].transform.position, Quaternion.identity);

                    Character character = m_Enemy.GetComponent<Character>();
                    if (character == null)
                    {
                        character = m_Enemy.GetComponentInChildren<Character>();
                    }

                    character.GetComponent<Character>().OnCharacterDeathHandled += Game.Instance.OnEnemyDeath;
                    character.GetComponent<Character>().OnCharacterDeathHandled += OnSpawnedEnemyDeath;
                    character.transform.SetParent(transform);
                    m_SpawnedSomething = true;

                    m_Timer = m_Delay;
                }
            }

        }
    }

    public void OnRiftDestroyed()
    {
        m_SpawnedSomething = false;
        Game.Instance.OnRiftDestroyed();
    }

    public void OnSpawnedEnemyDeath()
    {
        m_SpawnedSomething = false;
        Game.Instance.OnEnemyDeath();
    }
}

