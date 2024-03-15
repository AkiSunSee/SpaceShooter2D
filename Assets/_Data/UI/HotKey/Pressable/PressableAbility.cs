using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableAbility : Pressable
{
    [SerializeField] protected AbilitiesCode abitity;
    public override void Pressed()
    {
        if(GameCtrl.Instance.IsGamePaused()) return;
        PlayerCtrl.Instance.PlayerAbilities.Active(abitity);
        Cooldown cooldown = this.transform.parent.GetComponentInChildren<Cooldown>();
        if(cooldown == null) return;
        if(cooldown.GetCoolDownStatus()) return;
        float time = PlayerCtrl.Instance.PlayerAbilities.GetTimedelayOfAbility(abitity);
        Debug.Log("Ability cooldown time: "+time);
        cooldown.StartCoolDown(time);
    }
}
