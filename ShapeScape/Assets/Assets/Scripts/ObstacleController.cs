using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    // public variables
    public LayerMask obstaclesLayer;
    public Transform parentObject;
    public GameObject generatedBlockade;

    // private variables;
    private Rigidbody2D[] childRigidbody;
    private float startSpeed = 1.0f;
    private Vector2 generationPoint = new Vector2(0.0f, 7.0f);
    private float furthestBlock = -10;

	void Start () {
        
    }
	
	void Update () {
        // Reset variables
        childRigidbody = GetComponentsInChildren<Rigidbody2D>();
        furthestBlock = 0;

        // Check objects for updated position
        foreach (Rigidbody2D blockade in childRigidbody) {
            blockade.velocity = new Vector2(0.0f, -startSpeed);

            if (blockade.position.y > furthestBlock) {
                furthestBlock = blockade.position.y;   
            }
        }

        // Add block if enough space
        if (furthestBlock <= 4.0f) {
            Instantiate(generatedBlockade, generationPoint, Quaternion.identity, parentObject);
        }

        // Update speed variable
        startSpeed += 0.01f;
	}
}
