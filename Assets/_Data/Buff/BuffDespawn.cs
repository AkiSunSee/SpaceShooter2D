using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDespawn : DespawnByTime
{
    public override void DespawnObj(){
        BuffSpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValue(){
        base.ResetValue();
        this.MaxTime = 15f;
    }
}
