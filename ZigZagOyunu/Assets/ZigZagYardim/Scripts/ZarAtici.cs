using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ZarAtici : MonoBehaviour {

    public Text highScore, score;
    int HightScore, Score;

	// Use this for initialization
	void Start () {
        HightScore= PlayerPrefs.GetInt("HightScore", 0); //Skoru get çeker alır
        highScore.text = HightScore.ToString(); //Skoru ekrana yazdırır başlangıçta
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Score = Random.Range(1, 50); //Random 1 ile 50 arasında sayi üretir
            score.text = Score.ToString();
            if(Score>HightScore)
            {
                HightScore = Score;
                highScore.text = HightScore.ToString(); // Skoru int değeri stringe çevirir.
                PlayerPrefs.SetInt("HightScore", HightScore); //Son skoru hafızada tutar
            }
        }
	}
}
