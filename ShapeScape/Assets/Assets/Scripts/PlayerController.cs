using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody playerBody;

    public Touch fStartTouch;
    public Touch fEndTouch;

    public float speed = 1000f;

    private Vector3 moveLeft = new Vector3(-1.25f, 0f, 0f);
    private Vector3 moveRight = new Vector3(1.25f, 0f, 0f);

    private Vector3 startPos;

    private bool moveInput = false;
    private bool isMoving = false;

    private string moveDir = "";
    private float timeIncrement = 0;

	// Use this for initialization
	void Start () {
        playerBody = transform.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("left") && isMoving == false)
        {
            moveInput = true;
            moveDir = "left";
            startPos = playerBody.position;    
        } 
        else if (Input.GetKeyDown("right") && isMoving == false)
        {
            moveInput = true;
            moveDir = "right";
            startPos = playerBody.position;

        }

        //playerBody.transform.position = Vector3.Lerp(startPos, startPos+ moveLeft, 0.5f);

        if (moveInput == true)
        {
            isMoving = true;
            timeIncrement += 0.05f;

            switch (moveDir)
            {
                case "left":
                    //moveLeft
                    playerBody.transform.position = Vector3.Lerp(startPos, startPos + moveLeft, timeIncrement);
                    break;
                case "right":
                    //moveRight
                    playerBody.transform.position = Vector3.Lerp(startPos, startPos + moveRight, timeIncrement);
                    break;
                default:
                    break;
            }
        }

        if (timeIncrement >= 1.0f)
        {
            timeIncrement = 0;
            moveInput = false;
            isMoving = false;
        }
	}
}
