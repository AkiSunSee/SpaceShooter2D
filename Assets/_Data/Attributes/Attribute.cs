using System;
using System.Collections.Generic;

[Serializable]
public class Attribute{
    public AttributesCode attributesCode;
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
    
}
