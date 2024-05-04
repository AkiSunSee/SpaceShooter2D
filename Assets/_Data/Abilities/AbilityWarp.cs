using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityWarp : BaseAbility
{
    [Header("AbilityWarp")]
    protected Vector4 keyDirection;
    [SerializeField] protected bool isWarping = false;

    [SerializeField] protected Vector4 warpDirection;
    [SerializeField] protected float warpSpeed =0.5f;
    [SerializeField] protected float warpDistance = 2f;
    [SerializeField] protected StaminaBar staminaBar;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStaminaBar();
    }

    protected virtual void LoadStaminaBar(){
        if(this.staminaBar != null) return;
        this.staminaBar = GameObject.Find("StaminaBarMask").GetComponent<StaminaBar>();
        Debug.LogWarning(transform.name+" LoadStaminaBar",gameObject);
    }

    protected override void Update()
    {
        base.Update();
        this.CheckWarpDirection();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Warping();
    }

    protected virtual void CheckWarpDirection(){
        if(!this.isReady) return;
        if(this.isWarping) return;
        if (this.keyDirection.x == 1) this.WarpLeft();
        if (this.keyDirection.y == 1) this.WarpRight();
        if (this.keyDirection.z == 1) this.WarpUp();
        if (this.keyDirection.w == 1) this.WarpDown();
    }

    protected virtual void WarpLeft(){
        //Debug.Log("Left");
        this.warpDirection.x = 1;
    }

    protected virtual void WarpRight(){
        //Debug.Log("Right");
        this.warpDirection.y = 1;
    }

    protected virtual void WarpUp(){
        //Debug.Log("Up");
        this.warpDirection.z = 1;
    }

    protected virtual void WarpDown(){
        //Debug.Log("Down");
        this.warpDirection.w = 1;
    }

    protected virtual bool IsDirectionNotSet(){
        return this.warpDirection == Vector4.zero;
    }
    protected virtual void Warping(){
        if(this.isWarping) return;
        if(this.IsDirectionNotSet()) return;

        //Debug.LogWarning("Warping");
        //Debug.LogWarning(this.warpDirection);

        this.isWarping = true;
        Invoke(nameof(this.WarpFinish), this.warpSpeed);
    }

    protected virtual void WarpFinish(){
        this.MoveObj();
        //Debug.LogWarning("<b>  Warp Finish <b>");
        this.warpDirection = Vector4.zero;
        this.isWarping = false;
        this.Active();
    }

    protected override void Timing()
    {
        if(this.isReady) return;    
        this.timer += Time.fixedDeltaTime;
        this.staminaBar.UpdateBarUI(this.timer,this.delay);
        if(this.timer < delay) return;
        this.isReady = true;
    }

    protected virtual void MoveObj(){
        Transform obj = this.abilities.AbilityObjectCtrl.transform;
        Vector3 newPos = obj.position;
        if(this.warpDirection.x == 1) newPos.x -= this.warpDistance;
        if(this.warpDirection.y == 1) newPos.x += this.warpDistance;
        if(this.warpDirection.z == 1) newPos.y += this.warpDistance;
        if(this.warpDirection.w == 1) newPos.y -= this.warpDistance;

        Quaternion fxRot = this.GetFXQuaternion();
        Transform fx = FXSpawner.Instance.Spawn(FXSpawner.FX3, obj.position, fxRot);
        fx.gameObject.SetActive(true);
        obj.position = newPos;
    }

    protected virtual Quaternion GetFXQuaternion(){
        Vector3 vector3 = new Vector3();
        if(this.warpDirection.x ==1) vector3.z = 0;
        if(this.warpDirection.y ==1) vector3.z = 180;
        if(this.warpDirection.z ==1) vector3.z = -90;
        if(this.warpDirection.w ==1) vector3.z = 90;

        if(this.warpDirection.x==1 && this.warpDirection.w==1) vector3.z = 45;
        if(this.warpDirection.y==1 && this.warpDirection.w==1) vector3.z = 135;
        if(this.warpDirection.x==1 && this.warpDirection.z==1) vector3.z = -45;
        if(this.warpDirection.y==1 && this.warpDirection.z==1) vector3.z = -135;
        return Quaternion.Euler(vector3);
    }
}
