using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableAbility : Pressable
{
    [SerializeField] protected AbilitiesCode abitity;
    public override void Pressed()
    {
        PlayerCtrl.Instance.PlayerAbilities.Active(abitity);
    }
}
