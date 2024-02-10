using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffAbstract : AkiBehaviour
{
    [Header("Buff Abstract")]

    [SerializeField] protected BuffCtrl buffCtrl;
    public BuffCtrl BuffCtrl => buffCtrl;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadBuffCtrl();
    }

    protected virtual void LoadBuffCtrl(){
        if(this.buffCtrl != null) return;
        this.buffCtrl = transform.parent.GetComponent<BuffCtrl>();
        Debug.Log(transform.name+" LoadBuffCtrl", gameObject);
    }
}
