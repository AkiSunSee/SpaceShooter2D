using UnityEditor;
using UnityEngine;

public class BtnOpenInventory : BaseButton
{
    protected override void OnClick()
    {
        Debug.Log("click open");
        UIInventory.Instance.Toggle();
    }
}
