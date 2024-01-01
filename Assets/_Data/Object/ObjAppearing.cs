using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjAppearing : AkiBehaviour
{
    [Header("Obj Appearing")]
    [SerializeField] protected bool isAppearing = false;
    public bool IsAppearing => isAppearing;

    [SerializeField] protected bool appeared = false;
    public bool Appeared => appeared;

    protected virtual void FixedUpdate(){
        this.Appearing();
    }

    protected abstract void Appearing();

    public virtual void Appear(){
        this.appeared = true;
        this.isAppearing = false;
    }
}
