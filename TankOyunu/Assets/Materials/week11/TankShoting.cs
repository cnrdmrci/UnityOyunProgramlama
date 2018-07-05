using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoting : MonoBehaviour
{

    public Transform shellSpawn;
    public GameObject shellPrefab;
    float moveSpeed = 1500f;
    public Boolean isAI;

   
    void Start()
    {

    }

    
    private void FixedUpdate()
    {
        
        if (isAI) return;
        {

        }
        if (Input.GetKey(KeyCode.Space)) 
            Shoot();
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
           
        }
    }


    float nextShoot = 1f;
    float frequency = 10f;

    public void dur() { }

    public void Shoot()
    {
        if (Time.time > nextShoot)
        {
            GameObject shell = Instantiate(shellPrefab, shellSpawn.position, Quaternion.identity);
                                                                                                  
            shell.GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed * Time.deltaTime;
            nextShoot = Time.time + 1f/frequency;


        }
    }
   
}
