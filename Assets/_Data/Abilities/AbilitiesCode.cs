using UnityEngine;
using System;

public enum AbilitiesCode
{
    NoAbility = 0,

    Missle = 1,
    Specialized =2,
}

public class AbilitiesCodeParser{
    public static AbilitiesCode FromString(string abilityName){
        try{
            return (AbilitiesCode)System.Enum.Parse(typeof(AbilitiesCode), abilityName);
        }
        catch(ArgumentException ex){
            Debug.LogError(ex.ToString());
            return AbilitiesCode.NoAbility;
        }
    }
}
