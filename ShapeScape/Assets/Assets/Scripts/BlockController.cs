using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {
    public GameObject scObject;
    public ScoreController scoreController;
    public GameObject playerObject;
    public PlayerController player;
    public GameObject gameManagerObject;
    public GameManager gameManager;
    public float deactivationPoint = -10.0f;
    private float playerPosY = -3.5f;
    private bool addedPoint = false;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("PlayerController");
        player = playerObject.GetComponent<PlayerController>();

        scObject = GameObject.FindGameObjectWithTag("ScoreController");
        scoreController = scObject.GetComponent<ScoreController>();

        gameManagerObject = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    void Update () {
        
        if (transform.position.y <= deactivationPoint)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y <= playerPosY && addedPoint == false)
        {
            scoreController.UpdateScore();
            addedPoint = true;
        }
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        player.SetMoveInput(false);
        if (other.collider.tag == "Player")
        {
            gameManager.PauseGame();
        }
    }
}
