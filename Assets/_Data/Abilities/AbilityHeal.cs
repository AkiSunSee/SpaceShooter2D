using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHeal : BaseAbility
{
    [Header("Ability Heal")]
    [SerializeField] protected int healValuePerTime = 1;
    [SerializeField] protected float totalHealTime = 5f;
    [SerializeField] protected float timePer1Heal = 1f;
    protected float healTimeCount =0;
    [SerializeField] protected bool isHealing = false;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.delay = 20f;
        this.timer = this.delay;
        //for testing 
        int hp = this.abilities.AbilityObjectCtrl.DamageReceiver.HpMax-1;
        this.abilities.AbilityObjectCtrl.DamageReceiver.Deduct(hp);
    }

    public override void Active(){
        if(!this.isReady) return;
        base.Active();
        this.Heal();
    }

    protected virtual void Heal(){
        this.isHealing = true;
        StartCoroutine(Healing());
    }

    protected virtual void HealFinish(){
        this.isHealing = false;
        this.healTimeCount =0;
    }

    public IEnumerator Healing()
    {
        this.SpawnFX();
        this.abilities.AbilityObjectCtrl.DamageReceiver.Add(healValuePerTime);
        yield return new WaitForSeconds(timePer1Heal);
        healTimeCount+=timePer1Heal;
        if(healTimeCount >= totalHealTime){
            this.HealFinish();
        }
        if(isHealing) StartCoroutine(this.Healing());
    }

    protected virtual void SpawnFX(){
        Transform obj = this.abilities.AbilityObjectCtrl.transform;
        Transform fx = FXSpawner.Instance.Spawn(FXSpawner.FX4, obj.position, obj.rotation);
        fx.gameObject.SetActive(true);
    }
}
    
