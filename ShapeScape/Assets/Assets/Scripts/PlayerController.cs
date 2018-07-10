using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // public variables
    public GameManager gameManager;
    public GameObject firstBlock;
    public ScoreController scoreController;

    // private variables
    private Rigidbody2D playerBody;
    private Vector2 startPos;
    private Vector2 moveLeft = new Vector2(-1.25f, 0f);
    private Vector2 moveRight = new Vector2(1.25f, 0f);
    private bool isMoving = false;
    private bool moveInput = false;
    private string moveDir = "";
    private float timeIncrement = 0;
    private bool firstBlockPassed = false;

    private Collider2D playerCollider;


	/* Start
	 * Initialize character attributes
	 */
	void Start () {
        playerBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
	}

    /* LateUpdate
     * Update player position and states with every frame
     */
    void LateUpdate() {
        
        // Accept player input only the character has stopped moving and is in a valid position
        if (Input.GetKeyDown("left") && isMoving == false && playerBody.position.x > -1.25) {
            moveInput = true;
            moveDir = "left";
            startPos = playerBody.position;
        }
        else if (Input.GetKeyDown("right") && isMoving == false && playerBody.position.x < 1.25) {
            moveInput = true;
            moveDir = "right";
            startPos = playerBody.position;
        }

        // Update character position every frame update
        if (moveInput == true) {
            isMoving = true;
            timeIncrement += 0.1f;

            switch (moveDir) {
                case "left":
                    //moveLeft
                    playerBody.transform.position = Vector2.Lerp(startPos, startPos + moveLeft, timeIncrement);
                    break;
                case "right":
                    //moveRight
                    playerBody.transform.position = Vector2.Lerp(startPos, startPos + moveRight, timeIncrement);
                    break;
                default:
                    break;
            }
        }

        if (timeIncrement >= 1.0f) {
            timeIncrement = 0;
            moveInput = false;
            isMoving = false;
        }

        if (firstBlock.transform.position.y < transform.position.y && firstBlockPassed == false) {
            scoreController.UpdateScore();
            firstBlockPassed = true;
        }

    }

    public void resetPlayer() {
        timeIncrement = 0;
        moveInput = false;
        isMoving = false;
        firstBlockPassed = false;
    }

    private void OnCollisionEnter2D (Collision2D other) {
        moveInput = false;
        if (other.gameObject.tag == "block") {
            gameManager.PauseGame();   
        }
    }
}
