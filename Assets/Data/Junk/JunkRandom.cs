using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : AlphaMonoBehavior
{
    [SerializeField] protected JunkSpawnerController junkController;
    #region init
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJunkController();
    }

    protected virtual void LoadJunkController()
    {
        if (this.junkController != null) return;
        this.junkController = GetComponent<JunkSpawnerController>();
        Debug.Log(transform.name + ": LoadJunkController", gameObject);
    }
    #endregion
    protected override void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Transform randomePoint = this.junkController.SpawnPoints.GetRandom();
        Vector3 position = randomePoint.position;
        Quaternion rotation = transform.rotation;
        Transform obj =  this.junkController.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, position, rotation);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.JunkSpawning), 1f);
    }
}
