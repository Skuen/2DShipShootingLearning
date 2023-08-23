using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : AlphaMonoBehavior
{
    [SerializeField] protected JunkSpawnerController junkSpawnerController;
    [SerializeField] protected float randomDelay=1f;
    [SerializeField] protected float randomTimer=0f;
    [SerializeField] protected float randomLimit=9f;

    #region init
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkController();
    }
    //Load dependency
    protected virtual void LoadJunkController()
    {
        if (this.junkSpawnerController != null) return;
        this.junkSpawnerController = GetComponent<JunkSpawnerController>();
        Debug.Log(transform.name + ": LoadJunkController", gameObject);
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

        Transform randomePoint = this.junkSpawnerController.SpawnPoints.GetRandom();
        Vector3 position = randomePoint.position;
        Quaternion rotation = transform.rotation;


        Transform prefab = this.junkSpawnerController.JunkSpawner.RandomPrefab();
        Transform obj =  this.junkSpawnerController.JunkSpawner.Spawn(prefab, position, rotation);
        obj.gameObject.SetActive(true);
    }
    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.junkSpawnerController.JunkSpawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
}
