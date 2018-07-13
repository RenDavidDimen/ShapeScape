using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

    public GameObject playerObject;
    public PlayerController player;
    public GameObject gameManagerObject;
    public GameManager gameManager;
    public float deactivationPoint = -10.0f;

    public string key;
    private BoxCollider2D boxCollider;

    private void Start() {
        playerObject = GameObject.FindGameObjectWithTag("PlayerController");
        player = playerObject.GetComponent<PlayerController>();

        gameManagerObject = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update() {

        if (transform.position.y <= deactivationPoint)
        {
            Destroy(gameObject);
        }
    }

    public void SetGateKey(string shape){
        key = shape;
    }

    public string GetGateKey() {
        return key;
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.collider.tag == "Player") {

            if (player.GetPlayerShape() != key) {
                gameManager.PauseGame();
            } else {
                Destroy(gameObject);
            }
        }
    }
}
