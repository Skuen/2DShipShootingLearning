using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : AbilityObjectController
{
    protected override string GetObjectTypeString()
    {
        return ObjectType.Enemy.ToString();
    }
}
