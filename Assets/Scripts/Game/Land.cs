using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface SpawnsMonsters
{
    GameObject[] GetSpawnPoints();
}

public class SpawnsEnemies:MonoBehaviour,SpawnsMonsters
{
    public GameObject[] SpawnPoints;

    public GameObject[] GetSpawnPoints()
    {
        return SpawnPoints;
    }

}
public class Land : SpawnsEnemies
{


}
