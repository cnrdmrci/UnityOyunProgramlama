using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public bool isGameStarted;

    public Text HighScore, Score;
    int score,highScore;
	// Use this for initialization
	void Start () {
        isGameStarted = false;
        highScore = PlayerPrefs.GetInt("HighScore");
        HighScore.text = highScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {

          if(Input.GetKeyDown(KeyCode.Return))
          {
              StartGame();
          }
        /*  
        if(Input.touchCount>0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Stationary) // 0 demek tek dokunma 1 demek 2 dokunma
                StartGame();
        }
        */
        
	}
    private void StartGame()
    {
        isGameStarted = true;
        FindObjectOfType<WallMaker>().CreateNewWalls();
    }

    internal void RestartGame()
    {
        SceneManager.LoadScene(0); // 0 olunca sahneyi baştan başlatıyor.
    }
    public void MakeScore()
    {
        score++;
        Score.text = score.ToString(); // Skor değeri kaydetme ekrana yazar

        if(score>highScore)
        {
            highScore = score; // yeni değerini alıyor skor
            PlayerPrefs.SetInt("HighScore", highScore); // Skor değerini tutuyor
        }
    }
}
