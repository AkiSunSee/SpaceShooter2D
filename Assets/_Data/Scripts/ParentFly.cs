using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : AkiBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 dir = Vector3.right;

    void Update() {
        transform.parent.Translate(this.dir * this.moveSpeed * Time.deltaTime);
    }
    
    public virtual void SetMoveSpeed(float newMoveSpeed){
        this.moveSpeed = newMoveSpeed;
    }
}
