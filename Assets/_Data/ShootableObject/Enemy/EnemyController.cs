using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ShootableObjectController
{
    protected override string GetObjectTypeString()
    {
        return ObjectType.Enemy.ToString();
    }
}
