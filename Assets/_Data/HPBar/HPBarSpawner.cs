using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HPBarSpawner : Spawner
{
    private static HPBarSpawner instance;
    public static HPBarSpawner Instance { get => instance; }

    public static string HPBar1 = "HPBar";

    protected override void Awake() {
        base.Awake();
        if(HPBarSpawner.instance != null) Debug.LogError("Only 1 HPBarSpawner allow to exist");
        HPBarSpawner.instance = this;
    }

    public virtual void SpawnHPBar(string prefabName, Vector3 spawnPos, ShootableObjectCtrl shootableObjectCtrl, Transform target){
        Transform newHPBar = base.Spawn(HPBarSpawner.HPBar1,spawnPos,Quaternion.identity);

        newHPBar.GetComponentInChildren<HPBar>().SetShootableObjectCtrl(shootableObjectCtrl);
        newHPBar.GetComponentInChildren<FollowTarget>().SetTarget(target);
        
        newHPBar.gameObject.SetActive(true);
    }
}
