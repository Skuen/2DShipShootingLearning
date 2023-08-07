using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpact : BulletAbtract
{
    [Header("Bullet Impact")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.transform.parent.name);
        //Debug.Log(transform.parent.name);

        if (other.transform.parent == this.bulletController.Shooter) return;
        this.bulletController.DamageSender.Send(other.transform);
        this.CreateImpactFX(other);
        Debug.Log("Collided");
    }
    protected virtual void CreateImpactFX(Collider collider)
    {
        string fxName= this.getImpactFXName();

        Vector3 hitPosition = transform.position;
        Quaternion hitRoation = transform.rotation;
        Transform fxImpact =FXSpawner.Instance.Spawn(fxName, hitPosition, hitRoation);
        fxImpact.gameObject.SetActive(true);
    }
    protected virtual string getImpactFXName()
    {
        return FXSpawner.impact1;
    }
}
