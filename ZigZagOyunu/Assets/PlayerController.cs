using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    bool sagaMiBakiyor;
    public Rigidbody rb;
    GameManager gameManager;
    Animator animController;
    public Transform rayOrjin;
    public GameObject particlePrefab;
    float delay = 5.0f;
    float moveSpeed = 1.0f;

	// Use this for initialization
	void Start () {
        sagaMiBakiyor = true;
        gameManager = FindObjectOfType<GameManager>();
        animController = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        delay -= Time.deltaTime; // Zaman geçtikçe
        if(delay<0)
        {
            moveSpeed += 0.5f; // oyun hızı arttırma
            delay = moveSpeed;
        }
        if(Input.touchCount>0) // basılma var mı diye kontrol ediyor
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began) // 1 kere dokunmada 1 kez yön değiştiriyor.
                YonDegistir();
        }
        
		
         if(Input.GetKeyDown(KeyCode.Space))
        {
            YonDegistir();
        }
        
        if(transform.position.y<-2)
        {
            gameManager.RestartGame();
        }
	}
    private void YonDegistir()
    {
        sagaMiBakiyor = !sagaMiBakiyor;
        if(sagaMiBakiyor)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0); // Dönüşler açı vermeler "Quaternion ile veriliyor" !!!!
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }
    private void FixedUpdate()
    {
        if (!gameManager.isGameStarted) return; // GameManger da false bu değer , oyun başlamadı. Entera basınca başlıyor.
        else
        {
            animController.SetTrigger("gameStarted"); //animasyonu bağladık
            rb.position += transform.forward * Time.deltaTime*moveSpeed; //burdaki movespeed le çarpıp oyun hızını arttırdık
             
            if(!Physics.Raycast(rayOrjin.position,Vector3.down)) //Düşme Animasyonu için raycast kullandık altında cisim var mı diye baktık
            {
                animController.SetTrigger("falling");
            }
        }
       
    }
    private void OnTriggerEnter(Collider other) // bir şeye çarptığında other elmas oluyor 
    {
        if(other.tag=="Crystal")
        {

            gameManager.MakeScore();
            GameObject particle= Instantiate(particlePrefab, transform);
            Destroy(particle, 1);
            Destroy(other.gameObject);
        }
    }
}
