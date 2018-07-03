using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {

    public float destructionPoint = -10.0f;

	// Update is called once per frame
	void Update () {

        if (transform.position.y <= destructionPoint)
        {
            Destroy(gameObject);
        }
	}
}
