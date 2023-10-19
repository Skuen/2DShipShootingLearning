using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandom : AlphaMonoBehavior
{
    [Header("Spawner Random")]
    [SerializeField] protected SpawnerController spawnerController;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 1f;

    #region init
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkController();
    }
    //Load dependency
    protected virtual void LoadJunkController()
    {
        if (this.spawnerController != null) return;
        this.spawnerController = GetComponent<SpawnerController>();
        Debug.Log(transform.name + ": LoadController", gameObject);
    }
    #endregion

    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;

        Transform randomePoint = this.spawnerController.SpawnPoints.GetRandom();
        Vector3 position = randomePoint.position;
        Quaternion rotation = transform.rotation;


        Transform prefab = this.spawnerController.Spawner.RandomPrefab();
        Transform obj = this.spawnerController.Spawner.Spawn(prefab, position, rotation);
        obj.gameObject.SetActive(true);
    }
    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.spawnerController.Spawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
}
