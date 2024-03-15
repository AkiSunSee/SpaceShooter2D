using System.Collections;
using UnityEngine;

public abstract class BuffHandler : AkiBehaviour
{
    [SerializeField] protected float duration;
    [SerializeField] protected BuffGrabber buffGrabber;

    [SerializeField] protected AttributesCtrl attributesCtrl;
    [SerializeField] protected bool buffActived = false;
    protected float startTime;

    protected float baseValue;
    protected float buffValue;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBuffGrabber();
        this.LoadAttributesCtrl();
    }

    protected virtual void LoadBuffGrabber(){
        if(this.buffGrabber != null) return;
        this.buffGrabber = transform.parent.GetComponent<BuffGrabber>();
        Debug.LogWarning(transform.name+": LoadBuffGrabber",gameObject);
    }

     protected virtual void LoadAttributesCtrl(){
        if(this.attributesCtrl != null) return;
        this.attributesCtrl = this.buffGrabber.ShootableObjectCtrl.AttributesCtrl;
        Debug.LogWarning(transform.name+": LoadAttributesCtrl",gameObject);
    }

    public virtual IEnumerator Timing(){
        this.buffActived = true;
        this.startTime = Time.time;
        while(buffActived){
            float elapsedTime = Time.time - startTime; 
            yield return null;
            if(elapsedTime >= duration) buffActived = false;
            // Debug.Log(elapsedTime);
        }
        this.BuffEnd();
        // Debug.Log("Finish Buff Timing");
    }

    public virtual void StartBuff(float buffMultiplierValue){
        if(this.buffActived){
            this.startTime = Time.time;
            return;
        }
        this.GetBaseValue();
        this.Buff(buffMultiplierValue);
        StartCoroutine(this.Timing());
    }

    public virtual void SetDuration(float duration){
        this.duration = duration;
    }

    public abstract BuffCode GetBuffCode();
    protected abstract void Buff(float buffMultiplierValue);

    protected abstract void BuffEnd();

    protected abstract void GetBaseValue();
}
