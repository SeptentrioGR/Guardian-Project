using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOnlyWhenIsVisible : MonoBehaviour {
    public Shot shootSFX;

	void Start () {
        shootSFX.enabled = false;
    }

    private void OnBecameVisible()
    {
        shootSFX.enabled = true;
    }

    private void OnBecameInvisible()
    {
        shootSFX.enabled = false;
    }
}
