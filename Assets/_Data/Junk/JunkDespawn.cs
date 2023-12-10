using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDespawn : DespawnByDis
{
    public override void DespawnObj(){
       JunkSpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValue(){
        base.ResetValue();
        this.disLimit = 30f;
    }
}
