using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class UIInventoryCtrl : AkiBehaviour
{
    [Header("UI Inventory Item Spawner")]
    [SerializeField] protected UIInventoryItemSpawner uIInventoryItemSpawner;
    public UIInventoryItemSpawner UIInventoryItemSpawner => uIInventoryItemSpawner; 
    
    [SerializeField] protected Transform content;
    public Transform Content => content;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
        this.LoadUIIIS();
    }

    protected virtual void LoadContent(){
        if(this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
        Debug.LogWarning(transform.name+": LoadContent",gameObject);
    }

    protected virtual void LoadUIIIS(){
        if(this.uIInventoryItemSpawner != null) return;
        this.uIInventoryItemSpawner = transform.GetComponentInChildren<UIInventoryItemSpawner>();
        Debug.LogWarning(transform.name+": LoadUIIIS",gameObject);
    }
}
