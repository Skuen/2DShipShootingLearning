using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : AlphaMonoBehavior
{
    [Header("Player Abstract")]
    [SerializeField] protected PlayerController playerController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    protected virtual void LoadPlayerController()
    {
        if (this.playerController != null) return;
        this.playerController = transform.GetComponentInParent<PlayerController>();
        Debug.Log(transform.name + ": LoadPlayerController", gameObject);
    }
}
