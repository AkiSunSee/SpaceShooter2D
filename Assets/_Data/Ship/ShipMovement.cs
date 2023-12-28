using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : AkiBehaviour
{
   static InputManager instance;
   [SerializeField] protected Vector3 targetPos;
   [SerializeField] protected float speed = 0.01f;

   protected float distance;
   [SerializeField] protected float minDistance = 1f;

   protected virtual void FixedUpdate() {
      this.LookAtTarget();
      this.Moving();
   }

   protected virtual void LookAtTarget(){
      Vector3 diff = this.targetPos - transform.parent.position;
      diff.Normalize();
      float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
      transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
   }
   protected virtual void Moving(){
      this.distance = Vector3.Distance(transform.parent.position, targetPos);
      if(this.distance < this.minDistance) return;

      Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPos, this.speed);
      //Lerp(a,b,t) return point between a and b depend on t -- t=0 -> a, t=1 -> b, t=0.5 -> midpoint between a and b
      transform.parent.position = newPos;
   }
}
