
using UnityEngine;

public class Perspective :Sense {

    float fieldOfView;//camera görüş açııs perspectifi..
    float viewDistance;//kamera görüş uzunluğu...
    Transform playerTank;
    Vector3 dir;//yön vektörümüz..
   
    public Transform rayOrigin;
    public override void Initialize()
    {
        fieldOfView = 50f;
        viewDistance = 100f;
        detectionRate = 0f;
       playerTank = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void UpdateSense()
    {
        dir = (playerTank.position - transform.position).normalized;//yön vektörü hesaplandı
        if (Vector3.Angle(dir, transform.forward) < fieldOfView)//cisi görüş alanının içerisindeyse..
        {
            RaycastHit hitInfo;
           if(Physics.Raycast(rayOrigin.position,dir,out hitInfo , viewDistance))
            {
                Aspect aspect = hitInfo.collider.GetComponent<Aspect>();
                if (aspect != null)
                {
                    if(aspect.tankaspect== tAspect)
                    {
                        Debug.Log("Enemy detected..");
                    }
                }
            }
        }



        

    }

  
}
