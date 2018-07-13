using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // public variables
    public GameManager gameManager;
    public GameObject firstBlock;
    public ScoreController scoreController;

    public GameObject sprite_Tri;
    public GameObject sprite_Squ;
    public GameObject sprite_Hex;
    public GameObject sprite_Cir;

    // private variables
    private Rigidbody2D playerBody;
    private Vector2 startPos;
    private Vector2 moveLeft = new Vector2(-1.25f, 0f);
    private Vector2 moveRight = new Vector2(1.25f, 0f);
    private bool isMoving = false;
    private bool moveInput = false;
    private bool playerIsAlive = true;
    private string moveDir = "";
    private string currentShape = "square";
    private Sprite currentShapeSprite;
    private int shapeIndex = 1;
    private float timeIncrement = 0;
    private bool firstBlockPassed = false;


	/* Start
	 * Initialize character attributes
	 */
	void Start () {
        playerBody = GetComponent<Rigidbody2D>();
	}

    /* LateUpdate
     * Update player position and states with every frame
     */
    void LateUpdate() {

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

    public void movePlayer(string direction) {
        // Accept player input only the character has stopped moving and is in a valid position
        if (direction.Equals("left") && isMoving == false && playerBody.position.x > -1.25) {
            moveInput = true;
            moveDir = "left";
            startPos = playerBody.position;
        }
        else if (direction.Equals("right") && isMoving == false && playerBody.position.x < 1.25) {
            moveInput = true;
            moveDir = "right";
            startPos = playerBody.position;
        }

        // Change Player Shape values
        if (direction.Equals("up") && shapeIndex != 3 && playerIsAlive == true) {
            shapeIndex++;
            UpdatePlayerShape(shapeIndex);
        }
        else if (direction.Equals("down") && shapeIndex != 0 && playerIsAlive == true) {
            shapeIndex--;
            UpdatePlayerShape(shapeIndex);
        }
    }

    private void UpdatePlayerShape(int shapeIndexValue) {
        sprite_Tri.SetActive(false);
        sprite_Squ.SetActive(false);
        sprite_Hex.SetActive(false);
        sprite_Cir.SetActive(false);
        switch (shapeIndexValue) {
            case 0:
                currentShape = "triangle";
                sprite_Tri.SetActive(true);
                break;
            case 1:
                currentShape = "square";
                sprite_Squ.SetActive(true);
                break;
            case 2:
                currentShape = "hexagon";
                sprite_Hex.SetActive(true);
                break;
            case 3:
                currentShape = "circle";
                sprite_Cir.SetActive(true);
                break;
        }
    }

    public string GetPlayerShape() {
        return currentShape;
    }

    public void SetAlive(bool aliveState) {
        playerIsAlive = aliveState;
    }

    public bool IsAlive() {
        return playerIsAlive;
    }

    public void SetMoveInput(bool state) {
        moveInput = state;
    }

    public void ResetPlayer() {
        shapeIndex = 1;
        UpdatePlayerShape(shapeIndex);
        timeIncrement = 0;
        moveInput = false;
        isMoving = false;
        firstBlockPassed = false;
        playerIsAlive = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        moveInput = false;
        if (other.collider.tag == "block")
        {
            gameManager.PauseGame();
        }
    }
}
