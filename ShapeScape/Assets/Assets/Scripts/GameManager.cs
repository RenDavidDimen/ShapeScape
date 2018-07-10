using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PlayerController player;
    public ObstacleController obstacleController;
    public GameObject firstBlock;
    public ScoreController scoreController;
    public GameObject deathMenu;
    private Vector2 playerStartPos = new Vector2(0, -3.5f);
    private Vector2 blockStartPos = new Vector2(0, 7);
    private BlockController[] blocksArray;

    public void PauseGame() {
        obstacleController.stopBlocks();

        deathMenu.gameObject.SetActive(true);
        //StartCoroutine("RestartGameCoroutine");
    }

    public void Reset()
    {
        player.gameObject.SetActive(false);
        blocksArray = FindObjectsOfType<BlockController>();
        for (int i = 0; i < blocksArray.Length; i++)
        {
            Destroy(blocksArray[i].gameObject);
        }
        firstBlock.transform.position = blockStartPos;
        player.transform.position = playerStartPos;
        scoreController.Start();
        obstacleController.Start();
        player.resetPlayer();
        player.gameObject.SetActive(true);
        deathMenu.gameObject.SetActive(false);
    }

    //public IEnumerator RestartGameCoroutine()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    player.gameObject.SetActive(false);
    //    blocksArray = FindObjectsOfType<BlockController>();
    //    for (int i = 0; i < blocksArray.Length; i++) {
    //        Destroy(blocksArray[i].gameObject);
    //    }
    //    firstBlock.transform.position = blockStartPos;
    //    player.transform.position = playerStartPos;
    //    scoreController.Start();
    //    obstacleController.Start();
    //    player.resetPlayer();
    //    player.gameObject.SetActive(true);

    //}
}
