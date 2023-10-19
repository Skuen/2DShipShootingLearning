using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    public static EnemySpawner Instance { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        if (JunkSpawner.Instance != null && Instance != this)
        {
            Debug.LogError("Only 1 Enemy Spawner allow!!");
            Destroy(this);
            return;
        }
        EnemySpawner.Instance = this;
    }
}
