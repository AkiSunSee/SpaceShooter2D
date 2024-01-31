using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIHotKeyCtrl : AkiBehaviour
{
    private static UIHotKeyCtrl instance;
    public static UIHotKeyCtrl Instance => instance;

    [SerializeField] public List<HotKeySlot> hotKeySlots;

    protected override void Awake()
    {
        base.Awake();
        if(UIHotKeyCtrl.instance != null) Debug.LogError("Only 1 UIHotKeyCtrl can exist");
        UIHotKeyCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHotKeySlot();
    }

    protected virtual void LoadHotKeySlot(){
        if(this.hotKeySlots.Count>0) return;
        HotKeySlot[] arraySlots = GetComponentsInChildren<HotKeySlot>();
        this.hotKeySlots.AddRange(arraySlots);
        Debug.Log(transform.name+": LoadHotKeySlot",gameObject);
    }
}
