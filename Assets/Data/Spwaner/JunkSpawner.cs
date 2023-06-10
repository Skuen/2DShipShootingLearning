using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    public static JunkSpawner Instance { get; private set; }

    public static string meteoriteOne = "Meteorite_1";
    protected override void Awake()
    {
        base.Awake();
        if (JunkSpawner.Instance != null && Instance != this)
        {
            Debug.LogError("Only 1 Junk Spawner allow!!");
            Destroy(this);
            return;
        }
        JunkSpawner.Instance = this;
    }

}
