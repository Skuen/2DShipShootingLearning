using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : ParentFly
{
    [SerializeField] protected float min_Deviation = -9f;
    [SerializeField] protected float max_Deviation = 9f;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 0.5f;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetFlyDirection();
    }

    protected virtual void GetFlyDirection()
    {
        Vector3 camPosition = GameController.Instance.MainCamera.transform.position;
        Vector3 objPosition = transform.parent.position;

        camPosition.x += Random.Range(min_Deviation, max_Deviation);
        camPosition.z += Random.Range(min_Deviation, max_Deviation);

        Vector3 different = camPosition - objPosition;//direction = different between 2 vector3
        different.Normalize();//could be called direction
        float rotation_z = Mathf.Atan2(different.y, different.x) * Mathf.Rad2Deg;

        //Make the Junk fly toward camera direction
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rotation_z);
        Debug.DrawLine(objPosition, objPosition + different * 7, Color.red, Mathf.Infinity);
    }
}
