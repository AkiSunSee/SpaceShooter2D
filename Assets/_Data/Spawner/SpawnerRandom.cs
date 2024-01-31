using System.Collections;
using UnityEngine;

public class SpawnerRandom : AkiBehaviour
{
    [Header("Spawner Random")]
    [SerializeField] protected SpawnerCtrl spawnerCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected int randomLimit = 9;

    protected override void LoadComponents(){
        base.LoadComponents();
        LoadSpawnerCtrl();
    }

    protected virtual void LoadSpawnerCtrl(){
        if(spawnerCtrl != null) return;
        spawnerCtrl = GetComponent<SpawnerCtrl>();
        Debug.Log(transform.name + ": LoadSpawnerCtr", gameObject);
    }

    protected override void Start() {
        // for(int i=0;i<2;i++){
        //     Transform ranPoint = spawnerCtrl.SpawnPoints.GetRandom();
        //     Vector3 pos = ranPoint.position;
        //     Quaternion rot = transform.rotation;
        //     Transform random = spawnerCtrl.Spawner.GetRandomPrefab();
        //     Transform obj = spawnerCtrl.Spawner.Spawn(random, pos, rot);
        //     spawnerCtrl.Spawner.Despawn(obj);
        // }
        StartCoroutine(SpawnRoutine());
    }

    protected virtual IEnumerator SpawnRoutine() {
        while (true) {
            if (!RandomReachLimit()) {
                Transform ranPoint = spawnerCtrl.SpawnPoints.GetRandom();
                Vector3 pos = ranPoint.position;
                Quaternion rot = transform.rotation;
                Transform random = spawnerCtrl.Spawner.GetRandomPrefab();
                Transform obj = spawnerCtrl.Spawner.Spawn(random, pos, rot);
                obj.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(randomDelay);
        }
    }

    protected virtual bool RandomReachLimit() {
        int current = spawnerCtrl.Spawner.SpawnedCount;
        return current >= randomLimit;
    }
}
