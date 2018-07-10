using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuController : MonoBehaviour {

    public string mainMenu = "MainMenu";
    public GameManager gameManager;

    public void RestartGame() {
        gameManager.Reset();
    }

    public void QuitToMain() {
        SceneManager.LoadScene(mainMenu);
    }
}
