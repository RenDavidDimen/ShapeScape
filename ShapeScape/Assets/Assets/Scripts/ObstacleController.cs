using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    // public variables
    public LayerMask obstaclesLayer;
    public Transform parentObject;
    public GameObject generatedBlockade;
    public float startSpeed = 3.0f;
    public float maxSpeed = 7.0f;
    public float speedIncrement = 0.001f;
    public float lastBlockade = 4.0f;
    public float minBlockadeGenPoint = 3.0f;
    public float bloackadeGenPtIncrement = 0.0005f;

    // private variables;
    private Rigidbody2D[] childRigidbody;
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
        if (furthestBlock <= lastBlockade) {
            var newPlatform = Instantiate(generatedBlockade, generationPoint, Quaternion.identity, parentObject);
            newPlatform.gameObject.AddComponent<DestroySelf>();
        }

        // Remove block if past destruction point


        // Update speed variable
        if (startSpeed <= maxSpeed) {
            startSpeed += speedIncrement;
        }

        if (lastBlockade >= minBlockadeGenPoint) {
            lastBlockade -= 0.001f;
        }

        print(startSpeed);
	}
}
