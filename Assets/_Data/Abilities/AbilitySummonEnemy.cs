using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy : AbilitySummon
{   
    [Header("Summon Enemy")]
    [SerializeField] protected List<Transform> minions;
    [SerializeField] protected int summonLimit = 4;

    protected override void FixedUpdate(){
        base.FixedUpdate();
        this.ClearDeadMinions();
    }

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadEnemySpawner();
        this.SetPrefab();
    }

    protected virtual void LoadEnemySpawner(){
        if(this.spawner != null) return;
        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        this.spawner = enemySpawner.GetComponent<Spawner>();
        Debug.Log(transform.name+": Loadspawner", gameObject);
    }
    protected virtual void SetPrefab(){
        this.prefab = this.spawner.GetPrefabByName("Enemy1");
    }
    protected virtual bool IsSummonReachLimit(){
        return this.minions.Count >= summonLimit;
    }

    protected virtual void ClearDeadMinions(){
        foreach (Transform minion in minions)
        {
            if(minion.gameObject.activeSelf == false){
                this.minions.Remove(minion);
                return;
            }
        }
    }

    protected override void Summoning(){
        if(IsSummonReachLimit()) return;
        base.Summoning();
    }

    protected override Transform Summon(){
        Transform minion = base.Summon();
        minion.parent = this.abilities.AbilityObjectCtrl.transform;
        //to keep minion fly the same direction with parent direction
        this.minions.Add(minion);
        return minion;
    }
}
