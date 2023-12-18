using UnityEngine;
using System;

public enum ItemCode
{
    NoItem = 0,

    IronOre = 1,
    GoldOre = 2,
    GoldenSword = 1000,
}

public class ItemCodeParser{
    public static ItemCode FromString(string itemName){
        try{
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
        }
        catch(ArgumentException ex){
            Debug.LogError(ex.ToString());
            return ItemCode.NoItem;
        }
    }
}
