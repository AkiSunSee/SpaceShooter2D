using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSkillPoint : BaseText
{
    public virtual void UpdateText(int skillpoint){
        this.text.SetText("Skill Point: "+skillpoint.ToString());
    }
}
