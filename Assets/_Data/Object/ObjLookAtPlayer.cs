using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtPlayer : ObjLookAtTarget
{
    protected GameObject player;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadPlayer();
    }

    protected virtual void LoadPlayer(){
        if(this.player != null) return;
        this.player = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(transform.name + ": LoadPlayer", gameObject);
        this.SetTarget(this.player.transform);
    }
}
