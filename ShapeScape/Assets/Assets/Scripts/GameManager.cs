using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PlayerController player;
    public ObstacleController obstacleController;
    public GameObject firstBlock;
    private Vector2 playerStartPos = new Vector2(0, -3.5f);
    private Vector2 blockStartPos = new Vector2(0, 7);
    private DestroySelf[] blocksArray;

    // Use this for initialization
	void Start () {
    		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartGame() {
        StartCoroutine("RestartGameCoroutine");
    }

    public IEnumerator RestartGameCoroutine()
    {
        obstacleController.stopBlocks();

        yield return new WaitForSeconds(0.5f);
        player.gameObject.SetActive(false);
        blocksArray = FindObjectsOfType<DestroySelf>();
        for (int i = 0; i < blocksArray.Length; i++) {
            Destroy(blocksArray[i].gameObject);
        }
        firstBlock.transform.position = blockStartPos;
        player.transform.position = playerStartPos;
        obstacleController.Start();
        player.resetPlayer();
        player.gameObject.SetActive(true);

    }
}
