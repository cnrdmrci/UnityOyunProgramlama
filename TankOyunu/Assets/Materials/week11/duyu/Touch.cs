
using UnityEngine;

public class Touch : Sense
{
    Aspect aspect;
    public override void Initialize()
    {

    }

    public override void UpdateSense()
    {
        if (aspect!= null)
        {
            if(aspect.tankaspect== tAspect)
            {
                Debug.Log("touch detected");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        aspect = other.GetComponent<Aspect>();
    }
    private void onTriggerExit(Collider other)
    {
        aspect = null;
    }
   
  
}
 
