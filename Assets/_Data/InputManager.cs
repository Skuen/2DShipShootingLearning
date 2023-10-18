using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : AlphaMonoBehavior
{
    public static InputManager Instance { get; private set; }

    [SerializeField] public Vector3 mouseWorldPosition;
    [SerializeField] public float onFiring { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        if (Instance != null && Instance != this)
        {
            Debug.LogError("Only 1 InputManager allow!!");
            Destroy(this);
            return;
        }
        Instance = this;

        
    }
    private void FixedUpdate()
    {
        this.GetMousePosition();
    }

    private void Update()
    {
        this.GetMouseDown();
    }

    protected virtual void GetMousePosition()
    {
        this.mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
}
