using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DespawnByDis
{
    public override void DespawnObj(){
       EnemySpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValue(){
        base.ResetValue();
        this.disLimit = 30f;
    }
}
