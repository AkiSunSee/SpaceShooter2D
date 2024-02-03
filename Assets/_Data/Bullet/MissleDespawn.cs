using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleDespawn : DespawnByTime
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    [SerializeField] protected Transform model;

    protected bool Despawned;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadBulletCtrl();
        this.LoadModel();
    }

    protected virtual void LoadBulletCtrl(){
        if(this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }

    protected virtual void LoadModel(){
        if(this.model != null) return;
        this.model = transform.parent.Find("model");
        Debug.LogWarning(transform.name+": LoadModel",gameObject);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.Despawned = false;
        this.MaxTime = 1.5f;
        this.model.gameObject.SetActive(true);
        this.TurnOffImpact();
    }
    
    public override void DespawnObj(){
        if(Despawned) return;
        this.Despawned = true;
        Debug.Log("DespawnObj",gameObject);
        this.model.gameObject.SetActive(false);
        this.CreateFX();
        this.TurnOnImpact();
        StartCoroutine(this.WaitForDetectTrigger());
    }

    protected IEnumerator WaitForDetectTrigger(){
        yield return new WaitForSeconds(1f);
        BulletSpawner.Instance.Despawn(transform.parent);
    }

    protected virtual void CreateFX(){
        Transform fx = FXSpawner.Instance.Spawn(FXSpawner.FX7,transform.parent.position,Quaternion.identity);
        fx.gameObject.SetActive(true);
        Debug.Log("Spawn Missle Explosion FX",gameObject);
        this.MakeScreenShaking();
    }

    protected virtual void MakeScreenShaking(){
        ScreenShake screenShake = GameCtrl.Instance.transform.GetComponent<ScreenShake>();
        screenShake.TriggerShake(0.5f);
    }

    protected virtual void TurnOnImpact(){
        this.bulletCtrl.BulletImpact.gameObject.SetActive(true);
    }

    protected virtual void TurnOffImpact(){
        this.bulletCtrl.BulletImpact.gameObject.SetActive(false);
    }
}
