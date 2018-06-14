using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnLocation : MonoBehaviour {
    public GameObject m_PlayerPrefab;

	void Start () {
        m_PlayerPrefab = GameObject.FindGameObjectWithTag("Player");

        if (m_PlayerPrefab)
            m_PlayerPrefab.transform.position = transform.position +transform.up + transform.right;

    }
	

}
