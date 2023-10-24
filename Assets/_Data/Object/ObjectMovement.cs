using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : AlphaMonoBehavior
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float shipSpeed = 0.01f;
    [SerializeField] protected float distance = 0;
    [SerializeField] protected float minDistance = 1f;
    protected virtual void FixedUpdate()
    {
        this.Moving();
    }
    public virtual void SetSpeed(float speed)
    {
        this.shipSpeed = speed;
    }
    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(transform.position, this.targetPosition);
        if (this.distance < this.minDistance) return;

        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, this.shipSpeed);
        transform.parent.position = newPos;
    }
}