using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedBuffHandler : BuffHandler
{
    public override BuffCode GetBuffCode(){
        return BuffCode.AttackSpeedBuff;
    }

    protected override void Buff(float buffMultiplierValue){
        //this.buffGrabber.ShootableObjectCtrl.ObjShooting.SetShootDelay(baseValue/buffMultiplierValue);
        this.buffValue = this.baseValue - this.baseValue/buffMultiplierValue;
        this.attributesCtrl.DeductAttributeValue(AttributesCode.AttackSpeed,buffValue,false);
        this.buffGrabber.ShootableObjectCtrl.ObjShooting.SetShootDelay(this.attributesCtrl.GetAttributeByCode(AttributesCode.AttackSpeed).currentValue);
    }

    protected override void BuffEnd(){
        //this.buffGrabber.ShootableObjectCtrl.ObjShooting.SetShootDelay(baseValue);
        this.attributesCtrl.AddAttributeValue(AttributesCode.AttackSpeed,buffValue,false);
        //this.buffGrabber.ShootableObjectCtrl.ObjShooting.SetShootDelay(this.attributesCtrl.GetAttributeByCode(AttributesCode.AttackSpeed).currentValue);
        this.buffGrabber.ShootableObjectCtrl.ObjShooting.SetShootDelay(this.baseValue);
    }

    protected override void GetBaseValue(){
        // ShootableObjectCtrl sOC = this.buffGrabber.ShootableObjectCtrl.GetComponent<ShootableObjectCtrl>();
        // this.baseValue = sOC.ShootableObjectSO.shootingSpeed;
        this.baseValue = this.attributesCtrl.GetAttributeByCode(AttributesCode.AttackSpeed).baseValue;
    }
}
