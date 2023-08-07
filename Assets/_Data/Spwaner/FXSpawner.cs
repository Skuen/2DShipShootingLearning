using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    public static FXSpawner Instance { get; private set; }

    public static string smoke1 = "Smoke_1"; 
    public static string impact1 = "Impact_1"; 
    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner.Instance != null && Instance != this)
        {
            Debug.LogError("Only 1 FX Spawner allow!!");
            Destroy(this);
            return;
        }
        FXSpawner.Instance = this;


    }
}
