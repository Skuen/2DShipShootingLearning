using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : AlphaMonoBehavior
{
    [SerializeField] protected Spawner spawner;
    [SerializeField] protected SpawnPoints spawnPoints;
    public Spawner Spawner => spawner; 
    public SpawnPoints SpawnPoints { get => spawnPoints; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<Spawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }
    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints != null) return;
        this.spawnPoints = FindObjectOfType<SpawnPoints>();
        Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
    }
}
