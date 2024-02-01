using System.Collections;
using UnityEngine;

public class AbilityShield : BaseAbility
{
    [SerializeField] protected float shieldTime = 10;
    protected float shieldTimeCount = 0f;
    [SerializeField] protected bool isShieldOn = false;
    [SerializeField] protected Transform shield;

    protected Transform fxShield;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShield();
    }

    protected virtual void LoadShield(){
        if(this.shield != null) return;
        this.shield = transform.parent?.parent?.Find("Shield");
        Debug.LogWarning(transform.name+": LoadShield",gameObject);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.delay = 35f;
        this.timer = this.delay;
    }

    public override void Active(){
        if(this.shield == null){
            Debug.LogError("Can't find Shield - GameObject in" + transform.parent?.parent?.name);
            return;
        }
        if(!this.isReady) return;
        base.Active();
        this.Shield();
    }

    protected virtual void Shield(){
        this.isShieldOn = true;
        this.SpawnFX();
        this.shield.gameObject.SetActive(true);
        StartCoroutine(ShieldOn());
    }

    protected virtual void ShieldOff(){
        this.shield.gameObject.SetActive(false);
        FXSpawner.Instance.Hold(fxShield);
        this.isShieldOn = false;
        this.shieldTimeCount = 0;

    }

    public IEnumerator ShieldOn()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        shieldTimeCount += Time.deltaTime;
        if (shieldTimeCount >= shieldTime)
        {
            this.ShieldOff();
        }
        if (isShieldOn) StartCoroutine(this.ShieldOn());
    }

    protected virtual void SpawnFX(){
        Transform obj = this.abilities.AbilityObjectCtrl.transform;
        fxShield = FXSpawner.Instance.Spawn(FXSpawner.FX5, transform.position, obj.rotation);
        
        fxShield.SetParent(this.transform);
        fxShield.gameObject.SetActive(true);
    }

}
