using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMoveForward : ObjMovement
{
   [Header ("Move Forward")]
   [SerializeField] protected Transform moveTarget;
   [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;

   protected override void LoadComponents(){
      base.LoadComponents();
      this.LoadShootableObjectCtrl();
      this.LoadMoveTarget();
      this.LoadData();
   }

   protected override void FixedUpdate() {
      this.GetTargetPos();
      base.FixedUpdate();
   }

   protected virtual void LoadShootableObjectCtrl(){
      if(this.shootableObjectCtrl != null) return;
      this.shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
      Debug.LogWarning(transform.name+": LoadShootableObjectCtrl",gameObject);
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

   protected virtual void LoadData(){
      this.speed = this.shootableObjectCtrl.ShootableObjectSO.speed;
   }

}
