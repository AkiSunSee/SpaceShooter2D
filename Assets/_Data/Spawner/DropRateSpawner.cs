using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropRateSpawner : Spawner
{
    [SerializeField] protected float gameDropRate = 1;
    [SerializeField] protected float playerDropRate = 1;

    public virtual void SetPlayerDropRate(float newPlayerDropRate){
        this.playerDropRate = newPlayerDropRate;
    }

    protected virtual float GameDropRate(){
        return this.gameDropRate*playerDropRate;
    }

    protected virtual Vector3 RandomNearDropPos(Vector3 vector3){
        float randomX = Random.Range(0,1f);
        float randomY = Random.Range(0,1f);
        Vector3 newVector3 = new Vector3(vector3.x + randomX, vector3.y + randomY,0);
        return newVector3;
    }
}
