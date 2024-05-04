using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckBuffHandler : BuffHandler
{
    public override BuffCode GetBuffCode(){
        return BuffCode.LuckBuff;
    }

    protected override void Buff(float buffMultiplierValue){
        //ItemDropSpawner.Instance.SetPlayerDropRate(baseValue*buffMultiplierValue);
        this.buffValue = this.baseValue*buffMultiplierValue - this.baseValue;
        this.attributesCtrl.AddAttributeValue(AttributesCode.Luck,buffValue,false);
        ItemDropSpawner.Instance.SetPlayerDropRate(this.attributesCtrl.GetAttributeByCode(AttributesCode.Luck).currentValue);
    }

    protected override void BuffEnd(){
        //ItemDropSpawner.Instance.SetPlayerDropRate(baseValue);
        this.attributesCtrl.DeductAttributeValue(AttributesCode.Luck,buffValue,false);
        // ItemDropSpawner.Instance.SetPlayerDropRate(this.attributesCtrl.GetAttributeByCode(AttributesCode.Luck).currentValue);
        ItemDropSpawner.Instance.SetPlayerDropRate(this.baseValue);
    }

    protected override void GetBaseValue(){
        // ShootableObjectCtrl sOC = this.buffGrabber.ShootableObjectCtrl.GetComponent<ShootableObjectCtrl>();
        // this.baseValue = sOC.ShootableObjectSO.collectItemsRating;
        this.baseValue = this.attributesCtrl.GetAttributeByCode(AttributesCode.Luck).baseValue;
    }
}
