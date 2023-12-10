using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRotate : JunkAbstract
{
    [SerializeField] protected float DegreeRotatePerSecond = 15f;
    [SerializeField] protected float RotateSpeed = 2f;
    
    protected void FixedUpdate() {
        this.Rotate();
    }
    protected virtual void Rotate(){
        this.JunkCtrl.Model.Rotate(0f, 0f, DegreeRotatePerSecond * Time.fixedDeltaTime * RotateSpeed);
    }
}
