using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInvincible : BaseAbility
{
    [SerializeField] protected float invincibleTimeCount = 0f;
    [SerializeField] protected float invincibleTime = 10f;
    [SerializeField] protected Transform fx;
    protected DamageReceiver dmgReceiver;
    protected int hp;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.delay = 45f;
        this.timer = this.delay;
    }

    public override void Active(){
        if(!this.isReady) return;
        base.Active();
        this.BeingInvincible();
    }

    protected virtual void BeingInvincible(){
        this.dmgReceiver = this.abilities.AbilityObjectCtrl.DamageReceiver;
        if(this.dmgReceiver == null) return;
        this.hp = this.dmgReceiver.GetCurrentHP();
        this.dmgReceiver.gameObject.SetActive(false);
        this.CreateFX();
        StartCoroutine(this.TimingInvincibleTime());
    }

    protected virtual void BeingVincible(){
        this.invincibleTimeCount = 0;
        this.dmgReceiver.gameObject.SetActive(true);
        this.dmgReceiver.SetCurrentHP(this.hp);
        FXSpawner.Instance.Despawn(this.fx);
        FXSpawner.Instance.Hold(this.fx);
    }

    protected IEnumerator TimingInvincibleTime(){
        while(invincibleTimeCount <= invincibleTime){
            invincibleTimeCount += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        this.BeingVincible();
    }
    
    protected virtual void CreateFX(){
        Transform aOCTransform = this.abilities.AbilityObjectCtrl.transform;
        this.fx = FXSpawner.Instance.Spawn(FXSpawner.FX9, aOCTransform.position, Quaternion.identity);
        this.fx.gameObject.SetActive(true);
        this.fx.SetParent(aOCTransform);
    }

}
