using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : AkiBehaviour{
    [SerializeField] protected List<BaseAbility> abilities = new List<BaseAbility>();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        StartCoroutine(WaitForShip());
    }

    private IEnumerator WaitForShip()
    {
        while (PlayerCtrl.Instance.CurrentShip == null)
        {
            yield return null;
        }
        LoadAbilities();
    }

    protected virtual void LoadAbilities(){
        if (this.abilities.Count > 0) return;
        BaseAbility[] arrays =  PlayerCtrl.Instance.CurrentShip.GetComponentsInChildren<BaseAbility>();
        this.abilities.AddRange(arrays);
    }

    public virtual void Active(AbilitiesCode abilitiesCode){
        Debug.Log("PlayerAbilities active "+ abilitiesCode.ToString(),gameObject);
        foreach(BaseAbility ability in this.abilities){
            if(ability.transform.name == abilitiesCode.ToString()){
                ability.Active();
            }
        }
    }

    public virtual float GetTimedelayOfAbility(AbilitiesCode abilitiesCode){
        BaseAbility ability = this.GetAbility(abilitiesCode);
        if(ability == null) return 0;
        return ability.GetTimeDalay();
    }

    protected virtual BaseAbility GetAbility(AbilitiesCode abilitiesCode){
        foreach(BaseAbility ability in this.abilities){
            if(ability.transform.name == abilitiesCode.ToString()){
                return ability;
            }
        }
        return null;
    }
}
