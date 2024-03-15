using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootableObjectDamageReciver : DamageReceiver
{
    [Header("Shootable Object")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadShootableObjectCtrl();
        this.LoadDataShootableObjectSO();
    }

    protected virtual void LoadDataShootableObjectSO(){
        this.hpMax = this.shootableObjectCtrl.ShootableObjectSO.hpMax;
        this.sphereCollider.radius = this.shootableObjectCtrl.ShootableObjectSO.radius; 
    }
    
    protected virtual void LoadShootableObjectCtrl(){
        if(this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + ": LoadShootableObjectCtrl", gameObject);
    }

    protected override void OnDead(){
        this.OnDeadFX();
        this.DropOnDead();
        this.IncreaseScore();
        this.shootableObjectCtrl.Despawn.DespawnObj();
        
    }

    protected virtual void IncreaseScore(){
        int score = this.shootableObjectCtrl.ShootableObjectSO.score;
        ScoreManager.Instance.AddScore(score);
    }

    protected virtual void DropOnDead(){
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.shootableObjectCtrl.ShootableObjectSO.dropList, dropPos, dropRot);
        BuffSpawner.Instance.Drop(this.shootableObjectCtrl.ShootableObjectSO.buffList, dropPos, Quaternion.identity);
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
