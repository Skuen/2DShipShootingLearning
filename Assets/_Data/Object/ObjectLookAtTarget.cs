using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookAtTarget : AlphaMonoBehavior
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float rotSpeed = 3f;
    protected virtual void FixedUpdate()
    {
        this.LootAtTarget();
    }


    protected virtual void LootAtTarget()
    {
        Vector3 different = this.targetPosition - transform.parent.position;
        different.Normalize();
        float rotation_z = Mathf.Atan2(different.y, different.x) * Mathf.Rad2Deg;

        float time = this.rotSpeed * Time.fixedDeltaTime;
        Quaternion targetEuler = Quaternion.Euler(0f, 0f, rotation_z);
        Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, time);

        transform.parent.rotation = currentEuler;
    }
}
