using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextMenu : AkiBehaviour
{
    [SerializeField] protected UIItemInventory uIItemInventory;
    protected ItemInventory item;
    protected GenericMenu menu;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIII();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.LoadItem();
    }

    protected virtual void LoadUIII(){
        if(this.uIItemInventory != null) return;
        this.uIItemInventory = transform.parent.GetComponent<UIItemInventory>();
        Debug.LogWarning(transform.name+": LoadUIII",gameObject);
    }

    protected virtual void LoadItem(){
        this.item = this.uIItemInventory.ItemInventory;
    }
    private void SellItem()
    {
        //Debug.Log("Item sold!");
        Inventory inventory = PlayerCtrl.Instance.Inventory;
        //Debug.Log(item.itemProfile.itemCode+" - "+item.itemCount,gameObject);
        inventory.DeductItem(item.itemProfile.itemCode,item.itemCount);
        int currencyReceive = item.itemCount*item.itemProfile.currency;
        CurrencyManager.Instance.AddCurrency(currencyReceive);
        UIInventory.Instance.ReloadItems();
    }

    private void EquipItem()
    {
        //Debug.Log("Item equipped!");
        PlayerCtrl.Instance.Equipment.Equip(this.item);
    }

    private void UnEquipItem(){
        //Debug.Log("Item unequiped!");
        PlayerCtrl.Instance.Equipment.UnEquip(this.item);
    }

    protected virtual void AddItemEquip(){
        //Debug.Log(this.item.itemProfile.itemCode);
        if(PlayerCtrl.Instance.Equipment.IsItemEquiped(this.item)) this.menu.AddItem(new GUIContent("Equip"), true, UnEquipItem);
        this.menu.AddItem(new GUIContent("Equip"), false, EquipItem);
    }

    public void ShowContextMenu(Vector2 mousePosition)
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        mousePosition.y = screenSize.y - mousePosition.y;
        Rect rect = new Rect(mousePosition.x, mousePosition.y, 0, 0);
       
        this.menu = new GenericMenu();
        this.menu.AddItem(new GUIContent("Sell"), false, SellItem);
        if(this.item.itemProfile.itemType == ItemType.Equipment){
            this.AddItemEquip();
        }else this.menu.AddDisabledItem(new GUIContent("Equip"));
        this.menu.DropDown(rect);
    }
}
