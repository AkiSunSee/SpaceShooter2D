using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : AkiBehaviour
{
    [SerializeField] protected Image image;
    protected float timeCount = 0f;
    protected bool isCoolingDown = false;
    
    // protected override void Start(){
    //     Invoke(nameof(this.Test),2f);
    // }

    // protected virtual void Test(){
    //     StartCoroutine(this.StartCoolDown(5f));
    // }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
    }

    protected virtual void LoadImage(){
        if(this.image !=null) return;
        this.image = transform.parent.GetComponent<Image>();
        Debug.Log(transform.name+": LoadImage",gameObject);
    }

    public virtual void StartCoolDown(float time){
        this.image.fillAmount = 0;
        this.timeCount = 0;
        this.isCoolingDown = true;
        StartCoroutine(this.CoolingDown(time));
    }

    public IEnumerator CoolingDown(float time){
        float startTime = Time.time; 
        while(isCoolingDown){
            float elapsedTime = Time.time - startTime; 
            yield return null;
            //Debug.Log(elapsedTime + " / " + time);
            this.image.fillAmount = elapsedTime / time; 
            if(elapsedTime >= time) {
                isCoolingDown = false;
                break;
            }
        }
    }

    public virtual bool GetCoolDownStatus(){
        return this.isCoolingDown;
    }
}
