using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAppearingWithoutShoot : ShootableObjectAbstract,IObjectAppearObserver
{
    [Header("Without Shoot")]
    [SerializeField] protected ObjectAppearing objectAppearing;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.RegisterAppearEvent();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectAppearing();
    }
    protected virtual void LoadObjectAppearing()
    {
        if (this.objectAppearing != null) return;
        this.objectAppearing = GetComponentInChildren<ObjectAppearing>();
        Debug.Log(transform.name + ": ObjectAppearing", gameObject);
    }
    protected virtual void RegisterAppearEvent()
    {
        this.objectAppearing.ObserverAdd(this);
    }

    public void OnAppearStart()
    {
        this.shootableObjectController.ObjectShooting.gameObject.SetActive(false);
        this.shootableObjectController.ObjectLookAtTarget.gameObject.SetActive(false);
    }

    public void OnAppearFinish()
    {
        this.shootableObjectController.ObjectShooting.gameObject.SetActive(true);
        this.shootableObjectController.ObjectLookAtTarget.gameObject.SetActive(true);
    }
}
