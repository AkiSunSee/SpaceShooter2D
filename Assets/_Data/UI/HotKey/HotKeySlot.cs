using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HotKeySlot : AkiBehaviour, IDropHandler
{
    [SerializeField] protected bool isDropAble = true;
    [SerializeField] protected bool isSpecialized = false;
    [SerializeField] protected Image image;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
        if(isSpecialized) StartCoroutine(this.WaitForShip());
    }

    protected virtual void LoadImage(){
        if(this.image != null) return;
        this.image = GetComponent<Image>();
        Debug.LogWarning(transform.name+": LoadImage",gameObject);
    }

    protected virtual void LoadImageData(){
        this.image.sprite = PlayerCtrl.Instance.CurrentShip.ShootableObjectSO.sprite;
    }

    private IEnumerator WaitForShip()
    {
        while (PlayerCtrl.Instance == null || this.image == null ||PlayerCtrl.Instance.CurrentShip == null)
        {
            yield return null;
        }
        this.LoadImageData();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropObj = eventData.pointerDrag;
        DragItem dragItem = dropObj.GetComponent<DragItem>();
        if(dragItem == null) return;
        if(!this.DropAble()) return;
        if(this.IsHavingItem()){
            this.SwapItem(dragItem);
            return;
        }
        dragItem.SetRealParent(transform);
    }

    protected virtual bool IsHavingItem(){
        return transform.childCount > 0;
    }

    protected virtual bool DropAble(){
        return this.isDropAble;
    }

    protected virtual void SwapItem(DragItem dragItem){
        //Debug.Log("Swap");
        DragItem item = transform.GetComponentInChildren<DragItem>();
        item.SetRealParent(dragItem.GetRealParent());
        item.ReloadRealParent();
        dragItem.SetRealParent(transform);
    }
}
