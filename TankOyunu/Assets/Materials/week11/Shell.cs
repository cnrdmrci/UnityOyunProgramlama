using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

	
	void Start () {
        
	}
	private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player" || other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<TankHealth>().TakeDamage(2f);
        }
    }


}
