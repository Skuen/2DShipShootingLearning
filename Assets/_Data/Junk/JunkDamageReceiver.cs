using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDamageReceiver : DamageReceiver
{
    [Header("Junk")]
    [SerializeField] protected JunkController junkController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkController();
    }

    protected virtual void LoadJunkController()
    {
        if (this.junkController != null) return;
        this.junkController = transform.parent.GetComponent<JunkController>();
        Debug.Log(transform.name + ": LoadJunkController", gameObject);
    }
    protected override void OnDead()
    {
        this.OnDeadFX();
        this.DropItemOnDead();
        this.junkController.JunkDespawn.DespawnObject();
        Debug.Log("Junk destroyed");
    }
    protected virtual void DropItemOnDead()
    {
        ItemDropSpawner.Instance.Drop(this.junkController.ShootableObjectSO.dropList, transform.position, transform.rotation);
    }
    public override void Reborn()
    {
        this.hpMax = this.junkController.ShootableObjectSO.hpMax;
        base.Reborn();
    }
    public virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }
    public virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke1;
    }
}
