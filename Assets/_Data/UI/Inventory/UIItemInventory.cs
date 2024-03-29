using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItemInventory : AkiBehaviour, IPointerClickHandler
{
    [Header("UI Item Inventory")]

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;
    [SerializeField] protected Text itemName;
    public Text ItemName => itemName;

    [SerializeField] protected Text itemCount;
    public Text ItemCount => itemCount;

    [SerializeField] protected Image itemImage;
    public Image ItemImage => itemImage;

    [SerializeField] protected ContextMenu contextMenu;
    public ContextMenu ContextMenu => contextMenu;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemCount();
        this.LoadItemImage();
        this.LoadContextMenu();
    }

    protected virtual void LoadContextMenu(){
        if(this.contextMenu != null) return;
        this.contextMenu = GetComponentInChildren<ContextMenu>();
        Debug.LogWarning(transform.name+": LoadContextMenu",gameObject);
    }

    protected virtual void LoadItemName(){
        if(this.itemName != null) return;
        this.itemName = transform.Find("ItemName").GetComponent<Text>();
        Debug.LogWarning(transform.name+": LoadItemName",gameObject);
    }

    protected virtual void LoadItemCount(){
        if(this.itemCount != null) return;
        this.itemCount = transform.Find("ItemCount").GetComponent<Text>();
        Debug.LogWarning(transform.name+": LoadItemCount",gameObject);
    }

    protected virtual void LoadItemImage(){
        if(this.itemImage != null) return;
        this.itemImage = transform.Find("ItemImage").GetComponent<Image>();
        Debug.LogWarning(transform.name+": LoadItemImage",gameObject);
    }

    public virtual void ShowItem(ItemInventory item){
        this.itemInventory = item;
        this.itemName.text = item.itemProfile.itemName;
        this.itemCount.text = item.itemCount.ToString();
        this.itemImage.sprite = item.itemProfile.sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Vector2 mousePosition = eventData.position;
            this.contextMenu.ShowContextMenu(mousePosition);
        }
    }
}
