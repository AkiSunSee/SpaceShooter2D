using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BtnAddAttribute : BaseButton
{
    [SerializeField] protected UIAttribute uIattribute;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttribute();
    }

    protected virtual void LoadAttribute(){
        if(this.uIattribute != null) return;
        this.uIattribute = GetComponentInParent<UIAttribute>();
        Debug.LogWarning(transform.name+": LoadAttribute");
    }
    protected override void OnClick()
    {
        if(!LevelManager.Instance.HavingSkillPoint()) return;
        LevelManager.Instance.UsingSkillPoint();
        AttributesCode code = uIattribute.attribute.attributesCode;
        ShootableObjectCtrl sOC = PlayerCtrl.Instance.CurrentShip;
        if(code == AttributesCode.Attack){
            sOC.AttributesCtrl.AddAttributeValue(code, 1,true);
            sOC.ObjShooting.SetDamage((int)sOC.AttributesCtrl.GetAttributeByCode(code).baseValue);
        }
        if(code == AttributesCode.AttackSpeed){
            PlayerCtrl.Instance.CurrentShip.AttributesCtrl.DeductAttributeValue(code, 0.02f,true);
            sOC.ObjShooting.SetShootDelay(sOC.AttributesCtrl.GetAttributeByCode(code).baseValue);
        }
        if(code == AttributesCode.Luck){
            PlayerCtrl.Instance.CurrentShip.AttributesCtrl.AddAttributeValue(code,0.1f, true);
            ItemDropSpawner.Instance.SetPlayerDropRate(sOC.AttributesCtrl.GetAttributeByCode(code).baseValue);
        }
        if(code == AttributesCode.Speed){
            PlayerCtrl.Instance.CurrentShip.AttributesCtrl.AddAttributeValue(code,0.005f, true);
            sOC.ObjMovement.SetSpeed(sOC.AttributesCtrl.GetAttributeByCode(code).baseValue);
        }
        this.uIattribute.UpdateText();
    }
}
