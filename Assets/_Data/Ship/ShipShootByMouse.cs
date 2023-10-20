using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootByMouse : ObjectShooting
{
    protected override bool IsShooting()
    {
        //check input from mouse
        this.isShooting = InputManager.Instance.onFiring == 1;
        return this.isShooting;
    }
}
