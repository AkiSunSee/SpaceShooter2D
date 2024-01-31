using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static FXSpawner Instance { get => instance; }

    public static string FX1 = "Smoke_1";
    public static string FX2 = "Impact_1";
    public static string FX3 = "Smoke_2";
    public static string FX4 = "Healing";
    public static string FX5 = "ShieldCover";
    public static string FX6 = "ShieldSide";

    protected override void Awake() {
        base.Awake();
        if(FXSpawner.instance != null) Debug.LogError("Only 1 FXSpawner allow to exist");
        FXSpawner.instance = this;
    }
}
