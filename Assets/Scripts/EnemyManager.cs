using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Character[] listOfEnemies;
    private GameManager gameManager;

    public GameObject TimeRiftPrefab;
    public List<Transform> availableSpawnRiftPositions;
    public List<Transform> spawnRiftPositionsUsed;
    public List<TimeRift> listOfSpawnedRifts;
    public Transform RiftHolder;
    private int numberOfRifts = 0;

    public void SpawnRift(int RiftRemaining)
    {
        Transform spawnPoint = null;
        if (RiftRemaining > 0)
        {
            spawnPoint = availableSpawnRiftPositions[Random.Range(0, availableSpawnRiftPositions.Count)];
            GameObject rift = Instantiate(
                TimeRiftPrefab,
                spawnPoint.transform.position,
                Quaternion.identity);
            TimeRift timeRift = rift.GetComponent<TimeRift>();
            numberOfRifts++;
            timeRift.OnCharacterDeathHandled += Game.Instance.OnRiftDestroyed;
            timeRift.OnCharacterDeathHandled += Game.Instance.OnEnemyDeath;
            rift.transform.parent = RiftHolder;
            spawnRiftPositionsUsed.Add(transform);
            availableSpawnRiftPositions.Remove(spawnPoint);
        }

    }

    private void Awake()
    {

    }

    void Start()
    {
        gameManager = GameManager.Instance;

        foreach (Character item in listOfEnemies)
        {
            item.OnCharacterDeathHandled += Game.Instance.OnEnemyDeath;
        }

    }


    void Update()
    {

    }
}
