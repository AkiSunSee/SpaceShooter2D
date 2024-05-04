using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummon : BaseAbility
{
    [Header("Ability Summon")]
    [SerializeField] protected Spawner spawner;
    [SerializeField] protected Transform prefab;

    protected override void FixedUpdate(){
        base.FixedUpdate();
        this.Summoning();
    }

    protected virtual void Summoning(){
        if(!this.isReady) return;
        this.Summon(); 
    }

    protected virtual Transform Summon(){
        Transform minionPrefab;
        if(this.prefab == null) minionPrefab =  this.spawner.GetRandomPrefab();
        else minionPrefab = this.prefab;
        Vector3 spawnPos = this.abilities.AbilityObjectCtrl.SpawnPoints.GetRandom().position;
        Transform minion = this.spawner.Spawn(minionPrefab, spawnPos, transform.rotation);
        minion.gameObject.SetActive(true);
        this.Active();
        return minion;
    }
}
