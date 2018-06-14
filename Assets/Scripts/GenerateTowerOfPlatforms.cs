using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTowerOfPlatforms : MonoBehaviour
{
    public static GenerateTowerOfPlatforms Instance;
    private bool playerIsInTower = false;
    public int hightOfTower;
    public GameObject startPlatform;
    public GameObject endPlatform;
    public GameObject platform;
    public GameObject platformHolder;
    public GameObject timeMonster;
    public GameObject timeMonsterGo;
    private Vector3 previousLocation;
    public TeleportPlayerHere startingPos;
    private GameObject target;
    public GameObject riftHolder;
    private GameManager gameManager;

    private void Awake()
    {
        Instance = this;
        timeMonsterGo.GetComponent<FogOfTime>().StopMoving();
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        if (!playerIsInTower)
            return;

        if (!target.GetComponent<Character>().m_Alive)
        {
            TeleportBack();
        }
    }

    public void TeleportBack()
    {
        playerIsInTower = false;
        if (gameManager)
            gameManager.timeThreshold = 1;
        GameObject player = Game.Instance.GetPlayer();
        player.transform.position = previousLocation;
        if (AudioManager.Instance)
        {
            AudioManager.Instance.PlaySoundSFX(Constants.PlayerTeleportOut);
            AudioManager.Instance.SetMusic(Constants.LevelTheme);
        }
    }

    public void Teleport(GameObject user, GameObject target)
    {
        this.target = target;
        playerIsInTower = true;
        target.transform.position = riftHolder.transform.position;
        timeMonsterGo.GetComponent<FogOfTime>().StartMoving();
        if (gameManager)
            gameManager.timeThreshold = .5f;
        previousLocation = user.transform.position;
        startingPos.TeleportHere();
        target.transform.position = riftHolder.transform.position;
        if (AudioManager.Instance)
        {
            AudioManager.Instance.PlaySoundSFX(Constants.PlayerTeleportIn);
            AudioManager.Instance.SetMusic(Constants.FogMusic);
        }
    }


    public void DestroyPlatforms()
    {
        foreach (Transform item in platformHolder.transform)
        {
            DestroyImmediate(item.gameObject);
        }
    }

    public void Create()
    {
        GameObject monster = Instantiate(timeMonster, transform.position - transform.up * 10, Quaternion.identity);
        monster.transform.SetParent(platformHolder.transform);
        Vector3 pos = Vector3.zero;
        int dir = 1;
        GameObject platform = Instantiate(startPlatform, transform.position, Quaternion.identity);
        platform.transform.SetParent(platformHolder.transform);
        for (int i = 1; i < hightOfTower; i++)
        {
            int chance = Random.Range(0, 100);
            if (chance < 33)
            {
                platform = Instantiate(this.platform, transform.position + (transform.up * (i * 3f)), Quaternion.identity);
                platform.transform.SetParent(platformHolder.transform);
            }
            if (chance > 33 && chance <= 63)
            {
                platform = Instantiate(this.platform, transform.position + (transform.right * 2) + (transform.up * (i * 3f)), Quaternion.identity);
                platform.transform.SetParent(platformHolder.transform);
            }

            if (chance >= 63 && chance <= 100)
            {
                platform = Instantiate(this.platform, transform.position + (-transform.right * 2) + (transform.up * (i * 3f)), Quaternion.identity);
                platform.transform.SetParent(platformHolder.transform);
            }

        }
        platform = Instantiate(endPlatform, transform.position + (Vector3.up * hightOfTower * 3f), Quaternion.identity);
        platform.transform.SetParent(platformHolder.transform);
    }

}
