using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : Spawner
{
    private static ShipSpawner instance;
    public static ShipSpawner Instance { get => instance; }

    protected override void Awake() {
        base.Awake();
        if(ShipSpawner.instance != null) Debug.LogError("Only 1 ShipSpawner allow to exist");
        ShipSpawner.instance = this;
    }

    public virtual Transform Spawn(ShipCode shipCode){
        Vector3 spawnPos =  GameCtrl.Instance.MainCamera.transform.position;
        return this.Spawn(shipCode.ToString(), spawnPos, Quaternion.identity);
    }
}
