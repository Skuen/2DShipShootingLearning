using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaMonoBehavior : MonoBehaviour
{
    /// <summary>
    /// This is for OOP pattern design
    /// We put the methods that repeately use in this class
    /// </summary>
    // Start is called before the first frame update
    protected virtual void Reset()
    {
        this.LoadComponent();
        this.ResetValue();
    }

    protected virtual void ResetValue()
    {
        //For override
    }

    protected virtual void Awake()
    {
        //For override

    }
    protected virtual void LoadComponent()
    {
        //For override
    }
    protected virtual void Start()
    {
        //For override
    }
    protected virtual void OnEnable()
    {
        //For override
    }
}
