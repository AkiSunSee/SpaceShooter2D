using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float MaxTime = 10f;
    [SerializeField] protected float ExistTime = 0f;

    protected override void OnEnable(){
        base.OnEnable();
        this.ResetExistTime();
    }

    protected virtual void ResetExistTime(){
        this.ExistTime = 0;
    }
    protected override bool CanDespawn(){
        ExistTime+=Time.fixedDeltaTime;
        return (ExistTime >= MaxTime);  
    }
}
