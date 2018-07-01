using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    // public variables
    public LayerMask obstaclesLayer;
    public Transform parentObject;

    // private variables;
    private Rigidbody2D[] childRigidbody;
    private float startSpeed = 2.0f;

	void Start () {
        childRigidbody = GetComponentsInChildren<Rigidbody2D>();

        print(parentObject.position);
    }
	
	void Update () {

        foreach (Rigidbody2D blockade in childRigidbody) {
            blockade.velocity = new Vector2(0.0f, -startSpeed);
        }
	}
}
