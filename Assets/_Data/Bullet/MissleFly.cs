using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleFly : ParentFly
{
    protected override void ResetValue(){
        base.ResetValue();
        this.moveSpeed = 3f;
    }
}
