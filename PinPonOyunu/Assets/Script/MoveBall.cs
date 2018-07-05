using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBall : MonoBehaviour {
    public float speed;
    

    public GameObject solRaket;
    public GameObject sagRaket;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        speed = 15.0f;
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0)*speed;
        audioSource= GetComponent<AudioSource>();
        // leftRacket = solRaket.GetComponent<MoveRocket>();
        // rightRacket = sagRaket.GetComponent<MoveRocket>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!audioSource.isPlaying)
        {
            audioSource.Play();
        }
      
        if(other.gameObject.name=="solduvar")
        {
            sagRaket.GetComponent<Racket>().Skoryap();
            //Sağ raket +1 puan alacak
        }
        if(other.gameObject.name=="sagduvar")
        {
            solRaket.GetComponent<Racket>().Skoryap();
            //Sol raket +1 puan alacak
        }
        if(other.gameObject.name=="solraket")
        {
            //Eğer Top raketin üst tarafına çarparsa yönünü ayarla
            float yFark = transform.position.y - other.gameObject.transform.position.y; // top ile raketin y değerlerinin farkını al
            float raketUzunluk = other.collider.bounds.size.y; // Raketin uzunluğunu alıyor

            float y = yFark / raketUzunluk;
            Vector2 direction = new Vector2(1, y); // buldugunuz yön vektörü

            GetComponent<Rigidbody2D>().velocity = direction * speed; // bu vektorü topun hizina ekler.
        }
        if(other.gameObject.name=="sagraket")
        {
            //Eğer Top raketin üst tarafına çarparsa yönünü ayarla
            float yFark = transform.position.y - other.gameObject.transform.position.y; // top ile raketin y değerlerinin farkını al
            float raketUzunluk = other.collider.bounds.size.y; // Raketin uzunluğunu alıyor

            float y = yFark / raketUzunluk;
            Vector2 direction = new Vector2(-1, y); // buldugunuz yön vektörü

            GetComponent<Rigidbody2D>().velocity = direction * speed; // bu vektorü topun hizina ekler.
        }
    }
}
