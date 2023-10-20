using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : AlphaMonoBehavior
{
    [Header("Abilities")]
    [SerializeField] protected AbilityObjectController abilityObjectController;
    public AbilityObjectController AbilityObjectController => abilityObjectController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilityObjectController();
    }

    protected virtual void LoadAbilityObjectController()
    {
        if (this.abilityObjectController != null) return;
        this.abilityObjectController = transform.parent.GetComponent<AbilityObjectController>();
        Debug.Log(transform.name + ": LoadAbilityObjectController", gameObject);

    }

}
