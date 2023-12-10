using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDamageReciver : DamageReciver
{
    [Header("Junk")]
    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadJunkCtrl();
        this.LoadDataJunkSO();
    }

    protected virtual void LoadDataJunkSO(){
        this.hpMax = this.junkCtrl.JunkSO.hpMax;
        this.sphereCollider.radius = this.junkCtrl.JunkSO.radius; 
    }
    
    protected virtual void LoadJunkCtrl(){
        if(this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        //Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected override void OnDead(){
        this.OnDeadFX();
        this.junkCtrl.JunkDespawn.DespawnObj();

        DropManager.Instance.Drop(this.junkCtrl.JunkSO.dropList);
    }

    protected virtual void OnDeadFX(){
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName(){
        return FXSpawner.FX1;
    }
}
