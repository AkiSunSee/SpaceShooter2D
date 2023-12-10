using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : AkiBehaviour
{
    [SerializeField] protected Transform target;
    
    [SerializeField] protected float FollowSpeed = 2f;

    // protected override void LoadComponents(){
    //     base.LoadComponents();
    //     this.LoadTarget();
    // }

    // protected virtual void LoadTarget(){
    //     if(this.target != null) return;
    //     this.target = Transform.FindObjectOfType<Ship>(); 
    //     Debug.Log(transform.name + ": LoadTarget", gameObject);
    // }

    protected virtual void FixedUpdate() {
        this.Following();
    }

    protected virtual void Following(){
        if(this.target == null) return;
        transform.position = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * this.FollowSpeed);
    }
}
