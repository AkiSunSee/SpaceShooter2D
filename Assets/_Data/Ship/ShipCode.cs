using UnityEngine;
using System;

public enum ShipCode
{
    NoShip = 0,

    Fighter = 1,
    Healer = 2,
    Tanker = 3,
    Miner = 4,
}

public class ShipCodeParser{
    public static ShipCode FromString(string itemName){
        try{
            return (ShipCode)System.Enum.Parse(typeof(ShipCode), itemName);
        }
        catch(ArgumentException ex){
            Debug.LogError(ex.ToString());
            return ShipCode.NoShip;
        }
    }
}
