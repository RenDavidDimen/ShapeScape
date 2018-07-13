using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    // public variables
    public Transform parentObject;
    public GameObject[] blockades;
    public GameObject[] gates;
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
    private string gateKeyShape;


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


            // Adds gate if Blockade is type sides
            blockadeSelector = tempSelector;

            if (blockadeSelector == 1)
            {
                int genGate = Random.Range(0, 10);
                if (genGate <= 3)
                {
                    // Generate Gate
                    GameObject newGate = Instantiate(gates[genGate], generationPoint, Quaternion.identity, parentObject);
                    newGate.AddComponent<Gate>();
                    Gate tempGate = newGate.GetComponent<Gate>();

                    switch (genGate) {
                        case 0:
                            gateKeyShape = "triangle";
                            break;
                        case 1:
                            gateKeyShape = "square";
                            break;
                        case 2:
                            gateKeyShape = "hexagon";
                            break;
                        case 3:
                            gateKeyShape = "circle";
                            break;
                    }

                    tempGate.SetGateKey(gateKeyShape);

                    // Generate Platform
                    GameObject newPlatform = Instantiate(blockades[blockadeSelector], generationPoint, Quaternion.identity, parentObject);
                    newPlatform.AddComponent<BlockController>();
                    newPlatform.tag = "block";
                } else {
                    // Generate Platform
                    GameObject newPlatform = Instantiate(blockades[blockadeSelector], generationPoint, Quaternion.identity, parentObject);
                    newPlatform.AddComponent<BlockController>();
                    newPlatform.tag = "block";
                }
            }
            else
            {

                // Generate Platform
                GameObject newPlatform = Instantiate(blockades[blockadeSelector], generationPoint, Quaternion.identity, parentObject);
                newPlatform.AddComponent<BlockController>();
                newPlatform.tag = "block";
            }
        }

        // Update speed variable
        if (speed <= maxSpeed && gameIsRunning == true) {
            speed += speedIncrement;
        }

        if (lastBlockade >= minBlockadeGenPoint) {
            lastBlockade -= bloackadeGenPtIncrement;
        }
	}

    public void StopBlocks() {
        speed = 0;
        gameIsRunning = false;
    }
}
