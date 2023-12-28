using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandom : AkiBehaviour
{
    [Header("Spawner Random")]
    [SerializeField] protected SpawnerCtrl spawnerCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected int randomLimit = 9;
    

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadSpawnerCtrl();
    }

    protected virtual void LoadSpawnerCtrl(){
        if(this.spawnerCtrl != null) return;
        this.spawnerCtrl = GetComponent<SpawnerCtrl>();
        Debug.Log(transform.name + ": LoadSpawnerCtr", gameObject);
    }

    // protected override void Start() {
    //     this.Spawning();
    // }

    protected virtual void FixedUpdate() {
        this.Spawning();
    }

    protected virtual void Spawning(){
        if(this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if(this.randomTimer < this.randomDelay) return;
        this.randomTimer =0;

        Transform ranPoint = this.spawnerCtrl.SpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform. rotation;
        Transform random = this.spawnerCtrl.Spawner.GetRandomPrefab();
        Transform obj = this.spawnerCtrl.Spawner.Spawn(random, pos, rot);
        obj.gameObject.SetActive(true);
        //Invoke(nameof(this.Spawning), 1f);
    }

    protected virtual bool RandomReachLimit(){
        int current = this.spawnerCtrl.Spawner.SpawnedCount;
        return current >= this.randomLimit;
    }
}
