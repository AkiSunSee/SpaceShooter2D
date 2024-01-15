using UnityEditor;
using UnityEngine;

public class BtnCloseInventory : BaseButton
{
    protected override void OnClick()
    {
        Debug.Log("click close");
        UIInventory.Instance.Toggle();
    }
}
