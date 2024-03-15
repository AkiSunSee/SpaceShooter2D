using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScore : BaseText
{
    public virtual void UpdateText(int score){
        this.text.SetText("Score: "+score.ToString());
    }
}
