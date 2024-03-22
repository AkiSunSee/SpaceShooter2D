using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : AkiBehaviour
{
    [SerializeField] protected List<ItemInventory> usingEquipments = new List<ItemInventory>();
    [SerializeField] protected int maxEquipment = 3;

    public virtual void Equip(ItemInventory item){
        if(IsEquipmentFull()) return;
        this.usingEquipments.Add(item);
        this.ModifyPlayerAttribute(item.itemProfile.itemStats, true);
    }

    public virtual void UnEquip(ItemInventory item){
        if(!IsItemEquiped(item)) return;
        this.usingEquipments.Remove(item);
        this.ModifyPlayerAttribute(item.itemProfile.itemStats, false);
    }

    public bool IsEquipmentFull(){
        return this.usingEquipments.Count >= maxEquipment;
    }

    public bool IsItemEquiped(ItemInventory item){
        return this.usingEquipments.Contains(item);
    }

    protected virtual void ModifyPlayerAttribute(List<ItemStat> itemStats,bool isEquip){
        ShootableObjectCtrl shootableObjectCtrl = PlayerCtrl.Instance.CurrentShip;
        foreach (ItemStat itemStat in itemStats)
        {
            switch (itemStat.attribute)
            {
                case AttributesCode.Attack:
                    this.ModifyAttackStat(itemStat, shootableObjectCtrl, isEquip);
                    break;
                case AttributesCode.AttackSpeed:
                    this.ModifyAtkSpeedStat(itemStat, shootableObjectCtrl, isEquip);
                    break;
                case AttributesCode.Speed:
                    this.ModifySpeedStat(itemStat, shootableObjectCtrl, isEquip);
                    break;
                case AttributesCode.Luck:
                    this.ModifyLuckStat(itemStat, shootableObjectCtrl, isEquip);
                    break;
            }
        }
    }

    // protected virtual void GainItemStat(ItemStat itemStat){
    //     ShootableObjectCtrl shootableObjectCtrl = PlayerCtrl.Instance.CurrentShip;
    //     if(itemStat.attribute == AttributesCode.Attack) this.GainAttackStat(itemStat,shootableObjectCtrl);
    //     if(itemStat.attribute == AttributesCode.AttackSpeed) this.GainAtkSpeedStat(itemStat, shootableObjectCtrl);
    //     if(itemStat.attribute == AttributesCode.Speed) this.GainSpeedStat(itemStat,shootableObjectCtrl);
    //     if(itemStat.attribute == AttributesCode.Luck) this.GainSpeedStat(itemStat,shootableObjectCtrl);
    // }

    protected virtual void ModifyAttackStat(ItemStat itemStat, ShootableObjectCtrl sOC, bool isEquip){
        float baseValue = sOC.ShootableObjectSO.attack;
        float buffValue = baseValue*itemStat.percent/100;
        if(itemStat.isBuff == isEquip) sOC.AttributesCtrl.AddAttributeValue(itemStat.attribute,buffValue);
        else sOC.AttributesCtrl.DeductAttributeValue(itemStat.attribute,buffValue);
        sOC.ObjShooting.SetDamage((int)sOC.AttributesCtrl.GetAttributeByCode(itemStat.attribute).currentValue);
    }

    protected virtual void ModifyAtkSpeedStat(ItemStat itemStat, ShootableObjectCtrl sOC, bool isEquip){
        float baseValue = sOC.ShootableObjectSO.shootingSpeed;
        float buffValue = baseValue*itemStat.percent/100;
        if(itemStat.isBuff == isEquip) sOC.AttributesCtrl.DeductAttributeValue(itemStat.attribute,buffValue);
        else sOC.AttributesCtrl.AddAttributeValue(itemStat.attribute,buffValue);
        sOC.ObjShooting.SetShootDelay(sOC.AttributesCtrl.GetAttributeByCode(itemStat.attribute).currentValue);
    }

    protected virtual void ModifySpeedStat(ItemStat itemStat, ShootableObjectCtrl sOC, bool isEquip){
        float baseValue = sOC.ShootableObjectSO.speed;
        float buffValue = baseValue*itemStat.percent/100;
        if(itemStat.isBuff == isEquip) sOC.AttributesCtrl.AddAttributeValue(itemStat.attribute,buffValue);
        else sOC.AttributesCtrl.DeductAttributeValue(itemStat.attribute,buffValue);
        sOC.ObjMovement.SetSpeed(sOC.AttributesCtrl.GetAttributeByCode(itemStat.attribute).currentValue);
    }

    protected virtual void ModifyLuckStat(ItemStat itemStat, ShootableObjectCtrl sOC, bool isEquip){
        float baseValue = sOC.ShootableObjectSO.collectItemsRating;
        float buffValue = baseValue*itemStat.percent/100;
        if(itemStat.isBuff == isEquip) sOC.AttributesCtrl.AddAttributeValue(itemStat.attribute,buffValue);
        else sOC.AttributesCtrl.DeductAttributeValue(itemStat.attribute, buffValue);
        ItemDropSpawner.Instance.SetPlayerDropRate(sOC.AttributesCtrl.GetAttributeByCode(AttributesCode.Luck).currentValue);
    }

    // protected virtual void RemoveItemStat(ItemStat itemStat){
    //     ShootableObjectCtrl shootableObjectCtrl = PlayerCtrl.Instance.CurrentShip;
    //     if(itemStat.attribute == AttributesCode.Attack) this.GainAttackStat(itemStat,shootableObjectCtrl);
    //     if(itemStat.attribute == AttributesCode.AttackSpeed) this.GainAtkSpeedStat(itemStat, shootableObjectCtrl);
    //     if(itemStat.attribute == AttributesCode.Speed) this.GainSpeedStat(itemStat,shootableObjectCtrl);
    //     if(itemStat.attribute == AttributesCode.Luck) this.GainSpeedStat(itemStat,shootableObjectCtrl);
    // }

    // protected virtual void RemoveAttackStat(ItemStat itemStat, ShootableObjectCtrl sOC){
    //     float baseValue = sOC.ShootableObjectSO.attack;
    //     float buffValue = baseValue*itemStat.percent/100;
    //     if(itemStat.isBuff) sOC.AttributesCtrl.DeductAttributeValue(itemStat.attribute,buffValue);
    //     else sOC.AttributesCtrl.AddAttributeValue(itemStat.attribute,buffValue);
    //     sOC.ObjShooting.SetDamage((int)sOC.AttributesCtrl.GetAttributeByCode(itemStat.attribute).currentValue);
    // }
}
