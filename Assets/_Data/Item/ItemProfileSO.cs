using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "SO/ItemProfile")]
public class ItemProfileSO: ScriptableObject {
    public ItemCode itemCode = ItemCode.NoItem;
    public ItemType itemType = ItemType.NoType;
    public string itemName = "no-name";
    public int defaultMaxStack = 7;
    public List<ItemRecipe> upgradeLevels;

    public static ItemProfileSO FindByItemCode(ItemCode itemCode){
        var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));
        foreach(ItemProfileSO profile in profiles){
            if(profile.itemCode == itemCode) return profile;
        }
        return null;
    }
}