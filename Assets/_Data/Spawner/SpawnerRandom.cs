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
        Invoke(nameof(this.ReadySample),5f);
    }

    protected virtual void ReadySample(){
        foreach(Transform transform in this.spawnerCtrl.Spawner.GetPrefabsList()){
            Transform obj = this.SpawnObj(transform);
            this.spawnerCtrl.Spawner.Despawn(obj);
        }
        StartCoroutine(SpawnRoutine());
    }

    protected virtual IEnumerator SpawnRoutine() {
        while (true) {
            yield return new WaitForSeconds(randomDelay);
            if (!RandomReachLimit()) {
                Transform random = spawnerCtrl.Spawner.GetRandomPrefab();
                Transform obj = this.SpawnObj(random);
                obj.gameObject.SetActive(true);
            }
        }
    }

    protected virtual bool RandomReachLimit() {
        int current = spawnerCtrl.Spawner.SpawnedCount;
        return current >= randomLimit;
    }

    protected virtual Transform SpawnObj(Transform sample){
        Transform ranPoint = this.spawnerCtrl.SpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;
        Transform obj = this.spawnerCtrl.Spawner.Spawn(sample, pos, rot);
        return obj;
    }
}
