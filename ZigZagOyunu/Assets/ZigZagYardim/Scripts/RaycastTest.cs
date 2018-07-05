using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(transform.position, Vector3.down); // başlangıçta oluşturulması gerekiyor 
        RaycastHit hitInfo; 

        // if(Physics.Raycast(transform.position,Vector3.down)) // Raycast ışın kesişimi var mı diye bakıyor . Burda altta cisim var mı diye sorgu yapılıyor.
        if(Physics.Raycast(ray,out hitInfo))
        {
           // hitInfo.transform.name = "x"; çarptığı cisme isim verdi ve altta x cismi var yazılacak.
            Debug.Log("Asagida bir "+ hitInfo.transform.name+"var");
        }
	}
}
