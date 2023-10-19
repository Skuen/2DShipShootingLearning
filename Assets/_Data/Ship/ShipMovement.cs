using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : AlphaMonoBehavior
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float shipSpeed = 0.01f;
    [SerializeField] protected float distance = 0;
    [SerializeField] protected float minDistance = 1f;
    protected virtual void FixedUpdate()
    {
        this.LookAtTarget();
        this.Moving();
    }

    private void LookAtTarget()
    {
        //direction = different between 2 vector3
        Vector3 different = this.targetPosition - transform.parent.position;//could be called direction
        different.Normalize();
        float rotation_z = Mathf.Atan2(different.y, different.x) * Mathf.Rad2Deg;

        transform.parent.rotation= Quaternion.Euler(0, 0, rotation_z);
    }

    
    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(transform.position, this.targetPosition);
        if (this.distance < minDistance) return;
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, this.shipSpeed);
        transform.parent.position = newPos;
    }
}