using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootByDis : ObjShooting
{
    [Header("Shoot By Dis")]
    [SerializeField] protected float shootDis = 10f;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected Transform target;

    public virtual void SetTarget(Transform target){
        this.target = target;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.SetTarget(PlayerCtrl.Instance.CurrentShip.transform);
    }

    protected override bool IsShooting(){
        this.distance = Vector3.Distance(target.position, transform.parent.position);
        this.shooting = (distance <= shootDis);
        return this.shooting;
    }
    
}
