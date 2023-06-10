using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : AlphaMonoBehavior
{
    [SerializeField] protected float moveSpeed = 0;
    [SerializeField] protected Vector3 direction = Vector3.right;
    private void Update()
    {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }
}
