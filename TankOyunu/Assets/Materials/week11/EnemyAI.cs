using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    NavMeshAgent navMeshAgent;
    public Transform player;
    Animator fsm;
    public Transform ray;
    float maxCheckDistance= 10f;
    Vector3 RandomPos;
    float moveSpeed, rotSpeed;
   

    void Start()
    {
        fsm = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("player").transform;
        moveSpeed = 5f;
        rotSpeed = 5f;
    }
	void FixedUpdate () {

        
        Vector3 dir = (player.position - transform.position);
        dir = dir.normalized;

        float distance = Vector3.Distance(player.position,transform.position);

        fsm.SetFloat("distance", distance);

        float distanceFromWayPoint = Vector3.Distance(player.position, transform.position);
        fsm.SetFloat("distanceFromWayPoint", distanceFromWayPoint);


        RaycastHit hitInfo;
        Debug.DrawRay(player.position, dir * maxCheckDistance, Color.red);
        if (Physics.Raycast(ray.position, dir, out hitInfo, maxCheckDistance))
        {
            if (hitInfo.transform.tag == "Player")
            {
                fsm.SetBool("isVisible", true);
            }
            else
            {
                fsm.SetBool("isVisible", false);
            }
        }
        else
            fsm.SetBool("isVisible", false);



    }
 


    public void Shoot()
    {
        SetLookRotation();
        gameObject.GetComponent<TankShoting>().Shoot();
      
    }
    public void Takip()
    {
        SetLookRotation();
        navMeshAgent.SetDestination(player.position);
        
       

    }
    public void PatrolEnter()
    {
        gameObject.GetComponent<Wander>().Dolasma();
    }
    public void SetLookRotation()
    {
        if (!player) return;
        {

        }
        Vector3 dir = player.position - transform.position;
        dir = dir.normalized;
        Quaternion rot = new Quaternion();
        rot.SetLookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation,rot,0.2f);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
