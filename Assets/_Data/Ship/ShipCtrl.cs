using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : AkiBehaviour
{
    private static ShipCtrl instance;
    public static ShipCtrl Instance => instance;

    [SerializeField] public Inventory inventory;
    public Inventory Inventory => inventory;

    protected override void Awake(){
        base.Awake();
        if(ShipCtrl.instance != null) Debug.LogError("Only 1 ShipCtrl allow to exist");
        ShipCtrl.instance = this;
    }
    
    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadInventory();
    }

    protected virtual void LoadInventory(){
        if(this.inventory != null) return;
        this.inventory = transform.GetComponentInChildren<Inventory>();
        Debug.Log(transform.name + " LoadInventory",gameObject);
    }
}
