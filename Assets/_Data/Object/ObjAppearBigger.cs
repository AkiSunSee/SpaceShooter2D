using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAppearBigger : ObjAppearing
{
    [Header("Obj Appear Bigger")]
    [SerializeField] protected float currentScale = 0f;
    [SerializeField] protected float startScale = 0.1f;
    [SerializeField] protected float maxScale = 1f;
    [SerializeField] protected float speedScale = 0.01f;

    protected override void OnEnable(){
        base.OnEnable();
        this.isAppearing = true;
        this.InitScale();
    }

    protected override void Appearing(){
        if(!this.isAppearing) return;
        this.currentScale += this.speedScale;
        transform.parent.localScale = new Vector3(this.currentScale, this.currentScale, 0);
        if(this.currentScale >= this.maxScale) this.Appear();
    }

    protected virtual void InitScale(){
        transform.parent.localScale = Vector3.zero;
        this.currentScale = this.startScale;
    }

    public override void Appear(){
        base.Appear();
        this.transform.parent.localScale = new Vector3(this.maxScale, this.maxScale, 0);
    }
}
