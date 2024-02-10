using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckBuffHandler : BuffHandler
{
    public override BuffCode GetBuffCode(){
        return BuffCode.LuckBuff;
    }

    protected override void Buff(float buffMultiplierValue){
        ItemDropSpawner.Instance.SetPlayerDropRate(baseValue*buffMultiplierValue);
    }

    protected override void BuffEnd(){
        ItemDropSpawner.Instance.SetPlayerDropRate(baseValue);
    }

    protected override void GetBaseValue(){
        ShootableObjectCtrl sOC = this.buffGrabber.ShootableObjectCtrl.GetComponent<ShootableObjectCtrl>();
        this.baseValue = sOC.ShootableObjectSO.collectItemsRating;
    }
}
