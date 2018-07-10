using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {
    public GameObject scObject;
    public ScoreController scoreController;
    public float deactivationPoint = -10.0f;
    private float playerPosY = -3.5f;
    private bool addedPoint = false;

    void Start()
    {
        scObject = GameObject.FindGameObjectWithTag("ScoreController");
        scoreController = scObject.GetComponent<ScoreController>();
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
}
