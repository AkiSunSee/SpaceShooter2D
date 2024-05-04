using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuffHandler : BuffHandler
{
    public override BuffCode GetBuffCode(){
        return BuffCode.SpeedBuff;
    }

    protected override void Buff(float buffMultiplierValue){
        //this.buffGrabber.ShootableObjectCtrl.ObjMovement.SetSpeed(baseValue*buffMultiplierValue);
        this.buffValue = this.baseValue*buffMultiplierValue - this.baseValue;
        this.attributesCtrl.AddAttributeValue(AttributesCode.Speed,buffValue,false);
        this.buffGrabber.ShootableObjectCtrl.ObjMovement.SetSpeed(this.attributesCtrl.GetAttributeByCode(AttributesCode.Speed).currentValue);
    }

    protected override void BuffEnd(){
        // this.buffGrabber.ShootableObjectCtrl.ObjMovement.SetSpeed(baseValue);
        this.attributesCtrl.DeductAttributeValue(AttributesCode.Speed,buffValue,false);
        // this.buffGrabber.ShootableObjectCtrl.ObjMovement.SetSpeed(this.attributesCtrl.GetAttributeByCode(AttributesCode.Speed).currentValue);
        this.buffGrabber.ShootableObjectCtrl.ObjMovement.SetSpeed(this.baseValue);
    }

    protected override void GetBaseValue(){
        // ShootableObjectCtrl sOC = this.buffGrabber.ShootableObjectCtrl.GetComponent<ShootableObjectCtrl>();
        // this.baseValue = sOC.ShootableObjectSO.speed;
        this.baseValue = this.attributesCtrl.GetAttributeByCode(AttributesCode.Speed).baseValue;
    }
}
