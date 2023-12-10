using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : AkiBehaviour
{
    private static DropManager _instance;
    public static DropManager Instance => _instance;

    protected override void Awake() {
        base.Awake();
        if(DropManager._instance != null) Debug.LogError("Only 1 DropManager allow to exist");
        DropManager._instance = this;
    }

    public virtual void Drop(List<DropRate> dropList){
        Debug.Log(dropList[0].itemSO.itemName);
    }
}
