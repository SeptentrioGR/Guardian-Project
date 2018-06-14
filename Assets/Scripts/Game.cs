using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; set; }
    public bool gameOver = true;
    private GameManager gameManager;
    public TimeStatusCanvas timeStatusCanvas;
    public LevelManager levelManager;
    public GameObject gameCanvas;
    public GameOverMenu gameoverMenu;
    public WinMenu winMenu;
    public GameObject player;
    private EnemyManager enemyManager;
    public bool BossStage;
    float timer = 0;
    float delay = 2;

    void Awake()
    {
        Instance = this;
        gameManager = GameManager.Instance;
        player = GameObject.FindGameObjectWithTag(Constants.PlayerTag);
        enemyManager = GetComponent<EnemyManager>();
    }

    void Start()
    {
        gameCanvas.SetActive(true);
        int starts = GameObject.FindObjectsOfType<Coin>().Length;
        if (GameManager.Instance)
        {

            GameManager.Instance.TotalStars = starts;
        }
        if (BossStage)
        {

            StartBossFight();
        }
        else
        {
            StartGame();
        }
    }

    public void StartBossFight()
    {
        if (AudioManager.Instance)
            AudioManager.Instance.SetMusic(Constants.BossMusic);
        TransisionCanvas.Instance.FadeIn();
        gameOver = false;
        player.GetComponent<PlatformController>().GainPlayerControl(true);

        //timeScaleManipulation = 1;
    }

    public void StartGame()
    {
        if (AudioManager.Instance)
            AudioManager.Instance.SetMusic(Constants.LevelTheme);
        TransisionCanvas.Instance.FadeIn();
        gameOver = false;
        player.GetComponent<PlatformController>().GainPlayerControl(true);
        //timeScaleManipulation = 1;
        if (GameManager.Instance)
            GameManager.Instance.NewGame();
        enemyManager.SpawnRift(GameSettings.NumberOfRift);

        if (GameManager.Instance)
        {
            GameManager.Instance.GotDamaged = 0;
        }
    }

    void Update()
    {
        if (!gameOver)
        {
            //Time.timeScale = timeScaleManipulation;

            //if (timeScaleManipulation > 0.4)
            //{
            //    timeScaleManipulation -= timeThreshold * Time.deltaTime;
            //}
            //else
            //{
            //    GameOver = true;
            //}
            if (gameManager)
            {
                gameManager.clock.Update(GameManager.Instance.timeThreshold);
                timeStatusCanvas.UpdateText(gameManager.clock.GetString());

                if (gameManager.clock.TimeIsUp())
                {
                    timer -= Time.deltaTime;
                    if (timer < 0)
                    {
                        player.GetComponent<Character>().TakeDamage(1);
                        timer = delay;
                    }
                }
            }

            if (GameManager.Instance)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    GameManager.Instance.Pause();
                }
            }
        }
        else
        {
            player.GetComponent<PlatformController>().GainPlayerControl(false);
            gameoverMenu.gameObject.SetActive(true);
            if (AudioManager.Instance)
            {
                AudioManager.Instance.SetMusic(Constants.LoseMusic);
            }
        }

        if (!player.GetComponent<Guardian>().m_Alive)
        {
            gameOver = true;
        }
    }

    public void CollectStart()
    {
        if (gameManager)
            gameManager.StarCollected++;
    }

    public void OnRiftDestroyed()
    {
        GameManager gameManager = GameManager.Instance;
        if (gameManager)
        {
            gameManager.m_RiftRemaining--;
            if (gameManager.m_RiftRemaining <= 0)
            {
                gameManager.m_RiftRemaining = 0;
                gameManager.clock.AddTime();
            }
            Debug.Log("Rift Destroyed " + gameManager.m_RiftRemaining + " Remaining");
            enemyManager.SpawnRift(gameManager.m_RiftRemaining);
        }
    }

    public void OnEnemyDeath()
    {
        gameManager.clock.AddTime();
        // timeScaleManipulation += .25f;
        gameManager.EnemyKilled++;
    }

    public void GameFinished()
    {
        winMenu.gameObject.SetActive(true);
        if (AudioManager.Instance)
        {
            AudioManager.Instance.SetMusic(Constants.WinMusic);
        }
    }

    public GameObject GetPlayer()
    {
        return player;
    }

}

