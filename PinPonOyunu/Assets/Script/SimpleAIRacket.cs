using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleAIRacket : Racket {
    
    public Transform top;
    public  float referansDeger;

    private void Start()
    {
        moveSpeed = 5.0f;
    }
    private void FixedUpdate()
    {
        //Raket ile top arasindaki fark hesaplanacak.
        float fark = Mathf.Abs(top.position.y - transform.position.y);
        //Kosmak gerekiyor mu
        if (fark>referansDeger)
        {
            if(top.transform.position.y<transform.position.y)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * moveSpeed;
            }
            if (top.transform.position.y > transform.position.y)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * moveSpeed;
            }
        }
    }

    public void Skoryap()
    {
        Skore++;
        skoreText.text = Skore.ToString();
    }
}
