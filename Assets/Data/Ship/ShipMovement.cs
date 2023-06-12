using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float shipSpeed = 0.1f;
    private void FixedUpdate()
    {
        this.GetTargetPosition();
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

    protected virtual void GetTargetPosition()
    {
        this.targetPosition = InputManager.Instance.mouseWorldPosition;
        this.targetPosition.z = 0;
    }
    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, this.shipSpeed);
        transform.parent.position = newPos;
    }
}