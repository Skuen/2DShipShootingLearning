using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaMonoBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    protected virtual void Reset()
    {
        this.LoadComponent();
    }
    protected virtual void Awake()
    {
        this.LoadComponent();

    }
    protected virtual void LoadComponent()
    {
        //For override
    }
    protected virtual void Start()
    {
        //For override
    }
}
