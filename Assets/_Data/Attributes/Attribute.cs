using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.Experimental.Rendering;

[Serializable]
public class Attribute{
    public AttributesCode attributesCode;
    public float baseValue=0;
    public float currentValue =0;

    public virtual void Add(float addValue){
        this.currentValue += addValue;
    }

    public virtual void Deduct(float deductValue){
        float newValue = this.currentValue - deductValue;
        if(newValue <0){
            this.currentValue = 0;
            return;
        }
        this.currentValue = newValue;
    }
    
    public virtual void AddBase(float addValue){
        this.baseValue += addValue;
    }

    public virtual void DeductBase(float deductValue){
        float newValue = this.baseValue - deductValue;
        if(newValue <0){
            this.baseValue = 0;
            return;
        }
        this.baseValue = newValue;
    }
}
