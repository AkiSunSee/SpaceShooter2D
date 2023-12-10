using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAbstract : AkiBehaviour
{   [Header ("Bullet Abstract")]
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl {get => bulletCtrl;}

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadBulleCtrl();
    }

    protected virtual void LoadBulleCtrl(){
        if(this.bulletCtrl != null) return; 
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name +": LoadBulleCtrl", gameObject);
    }
}
