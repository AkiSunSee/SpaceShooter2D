using UnityEngine;
using System;

public enum BuffCode
{
    NoBuff = 0,

    AttackBuff = 1,
    SpeedBuff = 2,
    LuckBuff =3,
    AttackSpeedBuff =4,
}

public class BuffCodeParser{
    public static BuffCode FromString(string buffName){
        try{
            return (BuffCode)System.Enum.Parse(typeof(BuffCode), buffName);
        }
        catch(ArgumentException ex){
            Debug.LogError(ex.ToString());
            return BuffCode.NoBuff;
        }
    }
}
