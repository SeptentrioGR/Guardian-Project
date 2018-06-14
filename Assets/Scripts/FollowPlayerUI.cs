using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerUI : MonoBehaviour {
    public Character user;
    public Vector3 offset;


	void Update () {
		transform.position = Camera.main.WorldToScreenPoint(user.transform.position) + offset;
	}
}
