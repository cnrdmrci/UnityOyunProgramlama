
using UnityEngine;

public class Wander : MonoBehaviour
{

    Vector3 RandomPos;
    float moveSpeed, rotSpeed,minX, maxX,minZ, maxZ;
    Animator fsm;
 
    void Start()
    {
        moveSpeed = 5f;
        rotSpeed = 5f;
        float value = 10f;
        minX = -value;
        maxX = value;
        minZ = -value;
        maxZ = value;
        
    }
    void FixedUpdate()
    {
     
    }
    public void Dolasma()
    {
        if (Vector3.Distance(RandomPos, transform.position) < 1f)
            SetNewRandomTarget();


       MoveToTarget();
    }

    
   

    public void SetNewRandomTarget()
    {
             float xPos = Random.Range(minX, maxX);
             float zPos = Random.Range(minZ, maxZ);
             RandomPos = new Vector3(xPos, transform.position.y, zPos);
    }

    public void MoveToTarget()
    {
        Vector3 dir = (RandomPos - transform.position);
        dir = dir.normalized;
        
        Quaternion rotation = new Quaternion();
        rotation.SetLookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);
       
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}