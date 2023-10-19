using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjDmgRecevier : DamageReceiver
{
    [Header("Shootable Object")]
    [SerializeField] protected ShootableObjectController shootableObjectController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadController();
    }

    protected virtual void LoadController()
    {
        if (this.shootableObjectController != null) return;
        this.shootableObjectController = transform.parent.GetComponent<ShootableObjectController>();
        Debug.Log(transform.name + ": LoadController", gameObject);
    }
    protected override void OnDead()
    {
        this.OnDeadFX();
        this.DropItemOnDead();
        this.shootableObjectController.Despawn.DespawnObject();
        Debug.Log("Shootable Object destroyed");
    }
    protected virtual void DropItemOnDead()
    {
        ItemDropSpawner.Instance.Drop(this.shootableObjectController.ShootableObjectSO.dropList, transform.position, transform.rotation);
    }
    public override void Reborn()
    {
        this.hpMax = this.shootableObjectController.ShootableObjectSO.hpMax;
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
