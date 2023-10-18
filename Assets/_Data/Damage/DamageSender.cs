using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : AlphaMonoBehavior
{
    [SerializeField] protected int damage = 1;
    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;

        this.CreateImpactFX();
        this.Send(damageReceiver);
    }
    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
        //Debug.Log("Deducted");
    }
    protected virtual void CreateImpactFX()
    {
        string fxName = this.getImpactFXName();

        Vector3 hitPosition = transform.position;
        Quaternion hitRoation = transform.rotation;
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPosition, hitRoation);
        fxImpact.gameObject.SetActive(true);
    }
    protected virtual string getImpactFXName()
    {
        return FXSpawner.impact1;
    }

}
