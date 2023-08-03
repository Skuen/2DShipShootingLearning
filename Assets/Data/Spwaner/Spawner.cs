using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : AlphaMonoBehavior
{
    [Header("Spawner")]
    [SerializeField] protected Transform holder; 
    
    [SerializeField] protected int spawnedCount=0;

    public int SpawnedCount => spawnedCount;

    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs; 
    #region main
    protected override void LoadComponent()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }
    #endregion
    //methods
    #region init 
    private void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;

        Transform prefabsObject = transform.Find("Prefabs");
        foreach(Transform prefab in prefabsObject)
        {
            this.prefabs.Add(prefab);
        }

        this.HidePrefabs();

        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }

    private void HidePrefabs()
    {
        foreach(Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
    private void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);

    }
    #endregion
    //Spawning realate
    public virtual Transform Spawn(string prefabName,Vector3 spawnPosition, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);

        if (prefab == null) { 
            Debug.LogWarning("Prefab not found: " + prefabName); 
            return null;
        }
        
        return Spawn(prefab,spawnPosition,rotation);
    }
    public virtual Transform Spawn(Transform prefab, Vector3 spawnPosition, Quaternion rotation)
    {
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPosition, rotation);

        newPrefab.parent = this.holder;

        this.spawnedCount++;
        return newPrefab;
    }
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach(Transform poolObject in this.poolObjs)
        {
            if(poolObject.name== prefab.name)
            {
                this.poolObjs.Remove(poolObject);
                return poolObject;
            }
        }
        //If nothing in the pool create a new one
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach(Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }
    public virtual void Despawn(Transform obj)
    {
        if (this.poolObjs.Contains(obj)) return;

        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnedCount--;
    }
    public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
}
