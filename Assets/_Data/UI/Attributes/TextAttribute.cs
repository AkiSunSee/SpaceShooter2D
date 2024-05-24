using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAttribute : BaseText
{
    public virtual void UpdateText(Attribute attribute){
        this.text.text = attribute.attributesCode + ": "+attribute.baseValue;
    }
}
