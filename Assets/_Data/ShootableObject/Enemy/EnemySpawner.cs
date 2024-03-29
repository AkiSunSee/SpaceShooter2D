using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ShootableObjectSpawnerWithHPBar
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance; }

    protected override void Awake() {
        base.Awake();
        if(EnemySpawner.instance != null) Debug.LogError("Only 1 EnemySpawner allow to exist");
        EnemySpawner.instance = this;
    }
}
