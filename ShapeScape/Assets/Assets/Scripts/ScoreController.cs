using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    
    public AudioSource pointSound;
    public Text scoreText;
    public Text highScoreText;
    private int score;
    private int highScore;
    private string hsKey = "HighScore";


	public void Start () {
        score = 0;
        if (PlayerPrefs.HasKey(hsKey)) {
            highScore = PlayerPrefs.GetInt(hsKey);
        }
        PrintScore();
	}
	
    public void UpdateScore() {
        score++;
        pointSound.Play();
        if (score > highScore) {
            PlayerPrefs.SetInt(hsKey, score);
            highScore = score;
        }

        PrintScore();
    }

    void PrintScore() {
        scoreText.text = score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}
