using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : AkiBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropObj = eventData.pointerDrag;
        DragItem dragItem = dropObj.GetComponent<DragItem>();
        if(dragItem == null) return;
        if(this.IsHavingItem()){
            this.SwapItem(dragItem);
            return;
        }
        dragItem.SetRealParent(transform);
    }

    protected virtual bool IsHavingItem(){
        return transform.childCount > 0;
    }

    protected virtual void SwapItem(DragItem dragItem){
        //Debug.Log("Swap");
        DragItem item = transform.GetComponentInChildren<DragItem>();
        item.SetRealParent(dragItem.GetRealParent());
        item.ReloadRealParent();
        dragItem.SetRealParent(transform);
    }
}
