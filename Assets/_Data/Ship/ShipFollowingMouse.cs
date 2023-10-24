using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowingMouse : ObjectMovement
{
    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();
    }
    protected virtual void GetMousePosition()
    {
        this.targetPosition = InputManager.Instance.mouseWorldPosition;
        this.targetPosition.z = 0;
    }

}
