using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sense : MonoBehaviour, ISenseBehavior {

    protected float elapsedTime;
    protected float detectionRate;
    protected TankAspect tAspect = TankAspect.ENEMY;


    public abstract void Initialize();

    public abstract void UpdateSense();


    
    void Start () {
        Initialize();
    }
	
	
	void Update () {
        elapsedTime = Time.time;
        if (elapsedTime > detectionRate)
        {
            UpdateSense();
            detectionRate = elapsedTime + 0.1f;
        }
       
    }
}
