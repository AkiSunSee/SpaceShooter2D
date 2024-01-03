using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtTarget : ObjLook
{
   [Header("Obj Look At Target")]
   [SerializeField] protected Transform target;

   protected override void FixedUpdate() {
      this.GetTargetPos();
      base.FixedUpdate();
   }

   public virtual void SetTarget(Transform target){
      this.target = target;
   }
    
   protected virtual void GetTargetPos(){
      this.targetPos = this.target.position;
      this.targetPos.z = 0; //cause this is 2D game so z = 0
   }
}
