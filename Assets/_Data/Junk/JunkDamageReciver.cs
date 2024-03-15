using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDamageReciver : DamageReceiver
{
    [Header("Junk")]
    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadJunkCtrl();
        this.LoadDataShootableObjectSO();
    }

    protected virtual void LoadDataShootableObjectSO(){
        this.hpMax = this.junkCtrl.ShootableObjectSO.hpMax;
        this.sphereCollider.radius = this.junkCtrl.ShootableObjectSO.radius;
    }
    
    protected virtual void LoadJunkCtrl(){
        if(this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected override void OnDead(){
        this.OnDeadFX();
        this.DropOnDead();
        this.junkCtrl.JunkDespawn.DespawnObj();
    }

    protected virtual void DropOnDead(){
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.junkCtrl.ShootableObjectSO.dropList, dropPos, dropRot);
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
