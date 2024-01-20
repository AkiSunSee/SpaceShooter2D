using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIHotKeyCtrl : AkiBehaviour
{
    private static UIHotKeyCtrl instance;
    public static UIHotKeyCtrl Instance => instance;

    [SerializeField] public List<ItemSlot> itemSlots;

    protected override void Awake()
    {
        base.Awake();
        if(UIHotKeyCtrl.instance != null) Debug.LogError("Only 1 UIHotKeyCtrl can exist");
        UIHotKeyCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemSlots();
    }

    protected virtual void LoadItemSlots(){
        if(this.itemSlots.Count>0) return;
        ItemSlot[] arraySlots = GetComponentsInChildren<ItemSlot>();
        this.itemSlots.AddRange(arraySlots);
        Debug.Log(transform.name+": LoadItemSlots",gameObject);
    }
}
