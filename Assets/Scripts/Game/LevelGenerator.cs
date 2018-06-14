using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNew : MonoBehaviour
{
    public GameObject[] m_Prefab;
    public GameObject StartLand;
    public GameObject EndLevelPrefab;
    public int Length;

    public void CreateLevel()
    {
        GameObject previousLand = Instantiate(StartLand, transform.position, Quaternion.identity);
        GameObject prefabToInstansiate;

        for (int i = 0; i < Length; i++)
        {
            if (i == 9)
            {
                prefabToInstansiate = InstansiateLand(EndLevelPrefab, previousLand.transform.position + new Vector3(7, Random.Range(-1, 1), 0), Quaternion.identity);
            }
            else
            {
                prefabToInstansiate = InstansiateLand(m_Prefab[Random.Range(0, m_Prefab.Length)],
                    previousLand.transform.position + new Vector3(7, Random.Range(-1, 1), 0),
                    Quaternion.identity);
            }

            previousLand = prefabToInstansiate;
        }
    }
    void Start()
    {
        CreateLevel();
    }

    public GameObject InstansiateLand(GameObject prefab, Vector3 pos, Quaternion rot)
    {
        GameObject land = Instantiate(prefab, pos, rot);
        land.transform.SetParent(transform);
        return land;
    }


}
