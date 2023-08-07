using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float distanceLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCamera;
    //main
    
    protected override void LoadComponent()
    {
        this.LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log(transform.parent.name + ": LoadCamera ", gameObject);
    }
    //methods
    
    protected override bool IsDespawnable()
    {
        this.distance = Vector3.Distance(transform.position, this.mainCamera.position);
        if (distance > this.distanceLimit) return true;
        return false;
    }
    
}
