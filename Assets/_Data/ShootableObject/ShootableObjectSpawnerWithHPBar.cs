using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectSpawnerWithHPBar : Spawner
{   
    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation){

        Transform newPrefab = base.Spawn(prefab,spawnPos,rotation);
        ShootableObjectCtrl shootableObjectCtrl = newPrefab.GetComponent<ShootableObjectCtrl>();
        HPBarSpawner.Instance.SpawnHPBar(HPBarSpawner.HPBar1, spawnPos, shootableObjectCtrl, newPrefab);
        return newPrefab;
    }
}
