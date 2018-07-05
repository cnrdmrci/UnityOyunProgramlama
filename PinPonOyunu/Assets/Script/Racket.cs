using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Racket : MonoBehaviour {

    protected float moveSpeed;
    protected float Skore;
    public Text skoreText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Skoryap()
    {
        Skore++;
        skoreText.text = Skore.ToString();
    }
}
