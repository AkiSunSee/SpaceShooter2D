using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : AkiBehaviour
{
    public virtual void Active(AbilitiesCode abilitiesCode){
        Debug.Log("PlayerAbilities active "+ abilitiesCode.ToString());
    }
}
