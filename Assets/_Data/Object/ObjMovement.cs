using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : AkiBehaviour
{
   [SerializeField] protected Vector3 targetPos;
   [SerializeField] protected float speed = 0.01f;

   [SerializeField] protected float distance;
   [SerializeField] protected float minDistance = 1f;

   protected virtual void FixedUpdate() {
      this.Moving();
   }

   protected virtual void Moving(){
      this.distance = Vector3.Distance(transform.parent.position, targetPos);
      if(this.distance < this.minDistance) return;

      Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPos, this.speed);
      //Lerp(a,b,t) return point between a and b depend on t -- t=0 -> a, t=1 -> b, t=0.5 -> midpoint between a and b
      transform.parent.position = newPos;
   }

   public virtual void SetSpeed(float newSpeed){
      this.speed = newSpeed;
   }
}
