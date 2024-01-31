using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDamageReceiver : DamageReceiver
{
    [Header("Shield Object")]
    protected int shieldDurability = 10;
    protected float shieldRadius = 1f;

    protected override void OnEnable()
    {
        this.hpMax = shieldDurability;
        this.sphereCollider.radius = shieldRadius;
        base.OnEnable();
    }
    protected override void OnDead()
    {
        this.gameObject.SetActive(false);
    }

    protected virtual void OnTriggerEnter(Collider other){
        if(!other.transform.parent.TryGetComponent<BulletCtrl>(out var bulletCtrl)) return;
        if(bulletCtrl.Shooter == transform.parent) return;
        this.SpawnFX(other.transform.parent);
    }

    protected virtual void SpawnFX(Transform obj){
        Debug.Log("Spawn Shield Side");
        Transform fx = FXSpawner.Instance.Spawn(FXSpawner.FX6, transform.position, obj.rotation);
        fx.gameObject.SetActive(true);
    }
}
