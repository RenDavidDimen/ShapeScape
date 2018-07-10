using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    // public variables
    public Transform parentObject;
    public GameObject[] blockades;
    public float speed;
    public float maxSpeed = 7.0f;
    public float speedIncrement = 0.001f;
    public float lastBlockade;
    public float minBlockadeGenPoint = 2.0f;
    public float bloackadeGenPtIncrement = 0.0005f;

    // private variables;
    private Rigidbody2D[] childRigidbody;
    private Vector2 generationPoint = new Vector2(0.0f, 7.0f);
    private float furthestBlock = -10;
    private int blockadeSelector = 1;
    private int tempSelector;
    private float genBlockPoint = 3.5f;
    private float startSpeed = 2.5f;
    private bool gameIsRunning;


	public void Start () {
        speed = startSpeed;
        lastBlockade = genBlockPoint;
        blockadeSelector = 1;
        gameIsRunning = true;
    }
	
	void Update () {
        // Reset variables
        childRigidbody = GetComponentsInChildren<Rigidbody2D>();
        furthestBlock = 0;

        // Check objects for updated position
        foreach (Rigidbody2D blockade in childRigidbody) {
            blockade.velocity = new Vector2(0.0f, -speed);

            if (blockade.position.y > furthestBlock) {
                furthestBlock = blockade.position.y;   
            }
        }

        // Add block if enough space
        if (furthestBlock <= lastBlockade) {

            do {
                tempSelector = Random.Range(0, blockades.Length);
            } while (tempSelector == blockadeSelector);

            blockadeSelector = tempSelector;

            GameObject newPlatform = Instantiate(blockades[blockadeSelector], generationPoint, Quaternion.identity, parentObject);
            newPlatform.AddComponent<BlockController>();
            newPlatform.tag = "block";
            //newPlatform.
        }

        // Update speed variable
        if (speed <= maxSpeed && gameIsRunning == true) {
            speed += speedIncrement;
        }

        if (lastBlockade >= minBlockadeGenPoint) {
            lastBlockade -= bloackadeGenPtIncrement;
        }
	}

    public void stopBlocks() {
        speed = 0;
        gameIsRunning = false;
    }
}
