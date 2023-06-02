using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{

    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.1f;
    [SerializeField] protected float shootTimer = 0f;
    #region main

    /// <summary>
    /// main parts
    /// </summary>

    private void Update()
    {
        this.IsShooting();
    }
    private void FixedUpdate()
    {
        this.Shooting();
    }
    #endregion
    private void IsShooting()
    {
        //check input from mouse
        this.isShooting = InputManager.Instance.onFiring == 1;
    }
    private void Shooting()
    {
       
        //check bad condition first
        if (!this.isShooting) return;
        //delay shoot
        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return;
        //reset timer
        this.shootTimer = 0;
        //get position
        Vector3 spawnPosition = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne,spawnPosition, rotation);
        //check the bullet we get
        if (newBullet == null) return;
        //set the bullet true so we can see it
        newBullet.gameObject.SetActive(true);
        Debug.Log("Rat-ta-ta"); 
    }
   

}
