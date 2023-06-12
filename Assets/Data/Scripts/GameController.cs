using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : AlphaMonoBehavior
{
    public static GameController Instance { get; private set; }
    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera { get => mainCamera; }
    protected override void Awake()
    {
        base.Awake();
        if (Instance != null && Instance != this)
        {
            Debug.LogError("Only 1 GameController allow!!");
            Destroy(this);
            return;
        }
        Instance = this;


    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameController.FindObjectOfType<Camera>();
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }
}
