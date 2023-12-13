using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : DespawnByTime
{
    public override void DespawnObj(){
        ItemDropSpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValue(){
        base.ResetValue();
        this.MaxTime = 15f;
    }
}
