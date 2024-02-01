using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance; }

    public static string Bullet1 = "BulletRed";
    public static string Bullet2 = "BulletBlue";
    public static string Missle = "Missle";

    protected override void Awake() {
        base.Awake();
        if(BulletSpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        BulletSpawner.instance = this;
    }
}
