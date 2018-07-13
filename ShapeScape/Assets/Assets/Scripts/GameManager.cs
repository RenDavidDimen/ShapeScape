using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PlayerController player;
    public ObstacleController obstacleController;
    public GameObject firstBlock;
    public ScoreController scoreController;
    public GameObject deathMenu;
    public AudioSource deathSound;
    private Vector2 playerStartPos = new Vector2(0, -3.5f);
    private Vector2 blockStartPos = new Vector2(0, 7);
    private BlockController[] blocksArray;
    private Gate[] gatesArray;

    public void PauseGame() {
        obstacleController.StopBlocks();
        player.SetAlive(false);
        deathSound.Play();
        deathMenu.gameObject.SetActive(true);
    }

    public void Reset()
    {
        player.gameObject.SetActive(false);
        // Destroy Blocks
        blocksArray = FindObjectsOfType<BlockController>();
        for (int i = 0; i < blocksArray.Length; i++)
        {
            Destroy(blocksArray[i].gameObject);
        }
        // Destroy Gates
        gatesArray = FindObjectsOfType<Gate>();
        for (int i = 0; i < gatesArray.Length; i++)
        {
            Destroy(gatesArray[i].gameObject);
        }

        firstBlock.transform.position = blockStartPos;
        player.transform.position = playerStartPos;
        scoreController.Start();
        obstacleController.Start();
        player.ResetPlayer();
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
