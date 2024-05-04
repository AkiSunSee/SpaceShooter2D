using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIAttribute : AkiBehaviour
{
    [SerializeField] TextAttribute textAttribute;
    [SerializeField] public Attribute attribute;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextAttribute();
    }

    protected virtual void LoadTextAttribute(){
        if(this.textAttribute != null) return;
        this.textAttribute =  GetComponentInChildren<TextAttribute>();
        Debug.LogWarning(transform.name+" LoadTextAttribute");
    }

    public virtual void SetAttribute(Attribute attribute){
        this.attribute = attribute;
        this.UpdateText();
    }

    public virtual void UpdateText(){
        this.textAttribute.UpdateText(this.attribute);
    }
}

