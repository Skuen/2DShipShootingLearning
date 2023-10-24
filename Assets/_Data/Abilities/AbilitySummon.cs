using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummon : BaseAbility
{
    [Header("Ability Summon")]
    [SerializeField] protected Spawner spawner;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Summoning();
    }

    protected virtual void Summoning()
    {
        if (!this.isRead) return;
        this.Summon();
    }

    protected virtual Transform Summon()
    {
        Transform spawnPosition = this.abilities.AbilityObjectController.SpawnPoints.GetRandom();
        Transform minonPrefab = this.spawner.RandomPrefab();
        Transform minion = this.spawner.Spawn(minonPrefab, spawnPosition.position, spawnPosition.rotation);
        minion.gameObject.SetActive(true);
        this.Active();
        return minion;
    }
}
