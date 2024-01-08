using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : AkiBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount {get => spawnedCount;}

    protected override void LoadComponents(){
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadHolder(){
        if(this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.LogWarning(transform.name + ": LoadHolder",gameObject);
    }

    protected virtual void LoadPrefabs(){
        if(this.prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();

        Debug.LogWarning(transform.name+": LoadPrefabs",gameObject);
    }

    protected virtual void HidePrefabs(){
        foreach (Transform prefab in this.prefabs){
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation){
        Transform prefab = this.GetPrefabByName(prefabName);
        if(prefab == null){
            Debug.LogWarning("Prefab not found :"+prefabName);
            return null;
        }
        return this.Spawn(prefab, spawnPos, rotation);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation){

        Transform newPrefab = this.GetObjFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);

        newPrefab.parent = this.holder;
        this.spawnedCount++;
        return newPrefab;
    }

    protected virtual Transform GetObjFromPool(Transform prefab){
        foreach (Transform poolObj in this.poolObjs){
            if(poolObj.name == prefab.name){
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual void Despawn(Transform obj){
        this.poolObjs.Add(obj);
        this.spawnedCount--;
        obj.gameObject.SetActive(false);
    }

    public virtual Transform GetPrefabByName(string prefabName){
        foreach (Transform prefab in this.prefabs){
            if(prefab.name == prefabName) return prefab;
        }
        return null;
    }

    public virtual Transform GetRandomPrefab(){
        int random = Random.Range(0,this.prefabs.Count);
        return this.prefabs[random];
    }

    public virtual Transform Hold(Transform obj){
        obj.parent = this.holder;
        return transform;
    }
}
