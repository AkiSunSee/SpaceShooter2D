using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowMouse : ObjMovement
{
   protected override void FixedUpdate() {
      this.GetMousePos();
      base.FixedUpdate();
   }

   protected virtual void GetMousePos(){
      this.targetPos = InputManager.Instance.MouseWorldPos;
      this.targetPos.z = 0; //cause this is 2D game so z = 0
   }
 
}
