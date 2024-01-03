using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMoveForward : ObjMovement
{
   [Header ("Move Forward")]
   [SerializeField] protected Transform moveTarget;

   protected override void LoadComponents(){
      base.LoadComponents();
      this.LoadMoveTarget();
   }

   protected override void FixedUpdate() {
      this.GetTargetPos();
      base.FixedUpdate();
   }

   protected virtual void LoadMoveTarget(){
      if(this.moveTarget != null) return;
      this.moveTarget = transform.Find("MoveTarget");
      Debug.LogWarning(transform.name+": LoadMoveTarget",gameObject);
   }
    
   protected virtual void GetTargetPos(){
      this.targetPos = moveTarget.position;
      this.targetPos.z = 0; //cause this is 2D game so z = 0
   }
}
