using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryAbstract : AkiBehaviour
{   
    [Header("Inventory Abstract")]
    [SerializeField] protected Inventory inventory;

    protected override void LoadComponents(){
        base.LoadComponents();
        StartCoroutine(WaitForShip());
    }

    protected virtual void LoadInventory(){
        if(this.inventory != null) return;
        this.inventory = PlayerCtrl.Instance.Inventory;
    }

    private IEnumerator WaitForShip()
    {
        while (PlayerCtrl.Instance == null)
        {
            yield return null;
        }
        LoadInventory();
    }
}
