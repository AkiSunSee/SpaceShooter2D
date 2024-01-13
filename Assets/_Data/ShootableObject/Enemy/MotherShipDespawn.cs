using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipDespawn : DespawnByDis
{   
    public override void DespawnObj(){

        MotherShipSpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValue(){
        base.ResetValue();
        this.disLimit = 100f;
    }
}
