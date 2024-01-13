using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipSpawner : ShootableObjectSpawner
{
    private static MotherShipSpawner instance;
    public static MotherShipSpawner Instance { get => instance; }

    protected override void Awake() {
        base.Awake();
        if(MotherShipSpawner.instance != null) Debug.LogError("Only 1 MotherShipSpawner allow to exist");
        MotherShipSpawner.instance = this;
    }
}
