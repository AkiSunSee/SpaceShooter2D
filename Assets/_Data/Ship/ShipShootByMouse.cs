using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootByMouse : ObjShooting
{
    protected override bool IsShooting(){
        this.shooting = InputManager.Instance.IsRightMouseDown == 1;
        return this.shooting;
    }
    
}
