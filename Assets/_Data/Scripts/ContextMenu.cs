using UnityEditor;
using UnityEngine;

public class ContextMenu : AkiBehaviour
{
    [SerializeField] protected UIItemInventory uIItemInventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIII();
    }

    protected virtual void LoadUIII(){
        if(this.uIItemInventory != null) return;
        this.uIItemInventory = transform.parent.GetComponent<UIItemInventory>();
        Debug.LogWarning(transform.name+": LoadUIII",gameObject);
    }

    private void OnGUI()
    {
        if (Event.current.type == EventType.MouseDown && Event.current.button == 1)
        {
            // Tạo một ray từ vị trí chuột
            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Kiểm tra xem đối tượng được hit có phải là ContextMenu không
                ContextMenu clickedMenu = hit.collider.GetComponentInChildren<ContextMenu>();
                if (clickedMenu != null && clickedMenu.uIItemInventory == this.uIItemInventory)
                {
                    // Nếu là ContextMenu và có cùng contextMenuID, debug thông tin
                    Debug.Log(clickedMenu.uIItemInventory.gameObject.name);
                }
            }
        }
    }
    private void SellItem()
    {
        Debug.Log("Item sold!");
        Debug.Log(this.uIItemInventory,gameObject);
        ItemInventory item = this.uIItemInventory.ItemInventory;
        Inventory inventory = PlayerCtrl.Instance.Inventory;
        Debug.Log(item.itemProfile.itemCode+" - "+item.itemCount,gameObject);
        // inventory.DeductItem(item.itemProfile.itemCode,item.itemCount);
        // int currencyReceive = item.itemCount*item.itemProfile.currency;
        // CurrencyManager.Instance.AddCurrency(currencyReceive);
    }

    private void EquipItem()
    {
        Debug.Log("Item equipped!");
    }
}
