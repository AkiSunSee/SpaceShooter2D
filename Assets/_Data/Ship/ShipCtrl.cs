using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : AbilityObjectCtrl
{
    // [Header("Ship")]

    // [SerializeField] public Inventory inventory;
    // public Inventory Inventory => inventory;

    protected override string GetObjectTypeString(){
        return ShootableObjectType.Ship.ToString();
    }

    // protected override void LoadComponents(){
    //     base.LoadComponents();
    //     this.LoadInventory();
    // }

    // protected virtual void LoadInventory(){
    //     if(this.inventory != null) return;
    //     this.inventory = transform.GetComponentInChildren<Inventory>();
    //     Debug.Log(transform.name + " LoadInventory",gameObject);
    // }

}
