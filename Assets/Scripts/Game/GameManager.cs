using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    public int      m_RiftRemaining;
    public float    timeScaleManipulation;
    public int      StarCollected;
    public int      TotalStars;
    public float    timeThreshold;
    public Clock    clock;

    public int GotDamaged;
    public int Died;
    public int EnemyKilled;

    private int PlayerCurrentHealth;
    private int PlayerMaxHealth;

    private bool Paused;
    public GameObject PausedUI;
    private float deltaFixedTime;

    public int GetPlayerStat()
    {
        return PlayerCurrentHealth;
    }

    public void SetPlayerStat(int curHealth,int MaxHealth)
    {
        PlayerCurrentHealth = curHealth;
        PlayerMaxHealth = MaxHealth;
    }

    public void NewGame()
    {
        GotDamaged = 0;
        Died = 0;
        EnemyKilled = 0;
        StarCollected = 0;
    }
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        m_RiftRemaining = GameSettings.NumberOfRift;
        timeScaleManipulation = 0;
        clock = new Clock(2, 60, timeThreshold);
        deltaFixedTime = Time.fixedDeltaTime;
    }


    void Update()
    {

    }

    public void Pause()
    {
        Paused = !Paused;
        PausedUI.SetActive(Paused);
        if (Paused)
        {
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
        }else if (!Paused)
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = deltaFixedTime;
        }

    }

}
