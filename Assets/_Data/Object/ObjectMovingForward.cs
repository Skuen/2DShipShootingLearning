using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovingForward : ObjectMovement
{
    [SerializeField] protected Transform moveTarget;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMoveTarget();
    }
    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();
    }

    protected virtual void LoadMoveTarget()
    {
        if (this.moveTarget != null) return;
        this.moveTarget = transform.Find("MoveTarget");
        Debug.Log(transform.name + ": LoadMoveTarget", gameObject);
    }
    protected virtual void GetMousePosition()
    {
        this.targetPosition = moveTarget.position;
        this.targetPosition.z = 0;
    }
}
