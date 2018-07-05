using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    // public Transform target;
    public GameObject target;
    void Start()
    {
        //target = GameObject.FindWithTag("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target);
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
    }
}
