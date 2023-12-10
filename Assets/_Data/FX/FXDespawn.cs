using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDespawn : DespawnByTime
{
    protected override void OnEnable(){
        base.OnEnable();
        this.MaxTime = 2f;
    }
    public override void DespawnObj(){
        FXSpawner.Instance.Despawn(transform.parent);
    }
}
