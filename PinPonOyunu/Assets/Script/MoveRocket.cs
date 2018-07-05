using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRocket : Racket {

    public string dikeyEksen;
    
	// Use this for initialization
	void Start () {
        moveSpeed = 5.0f;
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
       
        float v = Input.GetAxisRaw(dikeyEksen);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * moveSpeed;
        Debug.Log(Skore + ":" + gameObject.name);
    }
    public void Skoryap()
    {
        Skore++;
        skoreText.text = Skore.ToString();
    }
}
