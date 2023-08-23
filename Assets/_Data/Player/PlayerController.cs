using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AlphaMonoBehavior
{
    public static PlayerController Instance { get; private set; }
    [SerializeField] protected ShipController currentShip;
    public ShipController CurrentShip => currentShip;
    [SerializeField] protected PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup { get => playerPickup; }
    protected override void Awake()
    {
        base.Awake();
        if (Instance != null && Instance != this)
        {
            Debug.LogError("Only 1 PlayerController allow!!");
            Destroy(this);
            return;
        }
        Instance = this;


    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerPickup();
    }

    protected virtual void LoadPlayerPickup()
    {
        if (this.playerPickup != null) return;
        this.playerPickup = transform.GetComponentInChildren<PlayerPickup>();
        Debug.Log(transform.name + ": LoadPlayerPickup", gameObject);
    }
}
