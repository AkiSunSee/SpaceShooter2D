using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PlayerCtrl : AkiBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;

    [SerializeField] protected ShipCtrl currentShip;
    public ShipCtrl CurrentShip => currentShip;

    [SerializeField] protected PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup => playerPickup;

    [SerializeField] protected PlayerAbilities playerAbilities;
    public PlayerAbilities PlayerAbilities => playerAbilities;

    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

    protected override void Awake(){
        base.Awake();
        if( PlayerCtrl.instance != null ) Debug.LogError("Only 1 PlayerCtrl allow to exist");
        PlayerCtrl.instance = this;
    }

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadPlayerPickup();
        this.LoadPlayerAbilities();
        this.LoadInventory();
    }

    protected virtual void LoadPlayerPickup(){
        if(this.playerPickup != null ) return;
        this.playerPickup = transform.GetComponentInChildren<PlayerPickup>();
        Debug.Log(transform.name + " LoadPlayerPickup", gameObject);
    }

    protected virtual void LoadPlayerAbilities(){
        if(this.playerAbilities != null ) return;
        this.playerAbilities = transform.GetComponentInChildren<PlayerAbilities>();
        Debug.Log(transform.name + " LoadPlayerAbilities", gameObject);
    }

    protected virtual void LoadInventory(){
        if(this.inventory != null) return;
        this.inventory = transform.GetComponentInChildren<Inventory>();
        Debug.LogWarning(transform.name +": LoadInventory",gameObject);
    }

    public virtual void SetCurrentShip(Transform ship){
        ShipCtrl shipCtrl = ship.GetComponent<ShipCtrl>();
        if(shipCtrl == null) return;
        this.currentShip = shipCtrl;
    }

}
