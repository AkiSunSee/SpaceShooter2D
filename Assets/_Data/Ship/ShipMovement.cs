using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
   static InputManager instance;
   [SerializeField] protected Vector3 targetPos;
   [SerializeField] protected float speed = 0.1f;

   void FixedUpdate() {
      this.GetTargetPos();
      this.LookAtTarget();
      this.Moving();
   }

   protected virtual void GetTargetPos(){
      this.targetPos = InputManager.Instance.MouseWorldPos;
      this.targetPos.z = 0; //cause this is 2D game so z = 0
   }
   protected virtual void LookAtTarget(){
      Vector3 diff = this.targetPos - transform.parent.position;
      diff.Normalize();
      float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
      transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
   }
   protected virtual void Moving(){
      Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPos, this.speed);
      //Lerp(a,b,t) return point between a and b depend on t -- t=0 -> a, t=1 -> b, t=0.5 -> midpoint between a and b
      transform.parent.position = newPos;
   }
}
