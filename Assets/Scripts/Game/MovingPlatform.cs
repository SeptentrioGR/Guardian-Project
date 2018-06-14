using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public Transform[] m_Waypoint;
    public int m_CurrentWaypoint;
    public float m_Speed;
    public float delay;
    private Vector3 velocity = Vector3.zero;
	// Use this for initialization
	void Start () {

        Invoke("StartMovingPlatform", Random.Range(1, 4));

    }

    public void StartMovingPlatform()
    {
        StartCoroutine(MovePlatform());
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.SmoothDamp(
            transform.position, m_Waypoint[m_CurrentWaypoint].position, ref velocity,m_Speed * Time.deltaTime);
	}

    public void ChangePos()
    {
        m_CurrentWaypoint++;

        if (m_CurrentWaypoint >= m_Waypoint.Length)
        {
            m_CurrentWaypoint = 0;
        }
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            ChangePos();
            delay = 4;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
