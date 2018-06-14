using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour {
    public Vector3 startingPos;

    public void Start()
    {
        startingPos = Game.Instance.GetPlayer().transform.position;
    }

    public void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<IDamagable>().TakeDamage(1);
            collision.gameObject.transform.position = startingPos;

        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
