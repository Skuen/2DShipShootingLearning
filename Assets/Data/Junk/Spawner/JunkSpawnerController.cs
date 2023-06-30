using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerController : AlphaMonoBehavior
{
    /// <summary>
    /// Only use for load Component and dependencies
    /// </summary>
    [SerializeField] protected JunkSpawner junkSpawner;
    [SerializeField] protected JunkSpawnPoints spawnPoints;
    public JunkSpawner JunkSpawner { get => junkSpawner;  }
    public JunkSpawnPoints SpawnPoints { get => spawnPoints; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkSpawner();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }
    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints != null) return;
        this.spawnPoints = FindObjectOfType<JunkSpawnPoints>();
        Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
    }
}
