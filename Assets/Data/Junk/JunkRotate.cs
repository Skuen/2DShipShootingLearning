using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRotate : JunkAbstract
{
    [SerializeField] protected float degreesPerSecond = 1;
    [SerializeField] protected float speed = 18f;
    protected virtual void FixedUpdate()
    {
        this.Rotating();
    }

    protected virtual void Rotating()
    {
        Vector3 eulers = new Vector3(0, 0, degreesPerSecond);
        this.JunkController.Model.Rotate(eulers * this.speed * Time.fixedDeltaTime);
    }
}
