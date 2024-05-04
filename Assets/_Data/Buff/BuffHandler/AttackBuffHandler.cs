using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBuffHandler : BuffHandler
{
    public override BuffCode GetBuffCode(){
        return BuffCode.AttackBuff;
    }
    
    protected override void Buff(float buffMultiplierValue){
        //int newValue = Mathf.CeilToInt(baseValue*buffMultiplierValue);
        //this.buffGrabber.ShootableObjectCtrl.ObjShooting.SetDamage(newValue);
        this.buffValue = this.baseValue*buffMultiplierValue - this.baseValue;
        this.attributesCtrl.AddAttributeValue(AttributesCode.Attack,buffValue,false);
        this.buffGrabber.ShootableObjectCtrl.ObjShooting.SetDamage((int)this.attributesCtrl.GetAttributeByCode(AttributesCode.Attack).currentValue);
    }

    protected override void BuffEnd(){
        // this.buffGrabber.ShootableObjectCtrl.ObjShooting.SetDamage((int)baseValue);
        this.attributesCtrl.DeductAttributeValue(AttributesCode.Attack,buffValue,false);
        //this.buffGrabber.ShootableObjectCtrl.ObjShooting.SetDamage((int)this.attributesCtrl.GetAttributeByCode(AttributesCode.Attack).currentValue);
        this.buffGrabber.ShootableObjectCtrl.ObjShooting.SetDamage((int)this.baseValue);
    }

    protected override void GetBaseValue(){
        // ShootableObjectCtrl sOC = this.buffGrabber.ShootableObjectCtrl.GetComponent<ShootableObjectCtrl>();
        // this.baseValue = sOC.ShootableObjectSO.attack;
        this.baseValue = this.attributesCtrl.GetAttributeByCode(AttributesCode.Attack).baseValue;
    }
}
