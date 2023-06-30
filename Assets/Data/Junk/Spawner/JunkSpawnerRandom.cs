using System;
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
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkController();
    }

    protected virtual void LoadJunkController()
    {
        if (this.junkSpawnerController != null) return;
        this.junkSpawnerController = GetComponent<JunkSpawnerController>();
        Debug.Log(transform.name + ": LoadJunkController", gameObject);
    }
    #endregion
    protected override void Start()
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
        Transform obj =  this.junkSpawnerController.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, position, rotation);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.JunkSpawning), 1f);
    }
    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.junkSpawnerController.JunkSpawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
}
