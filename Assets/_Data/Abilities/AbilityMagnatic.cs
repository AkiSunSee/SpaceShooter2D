using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class AbilityMagnatic : BaseAbility
{
    [SerializeField] protected float magneticCoolDown = 7f;
    [SerializeField] protected float magnaticFieldRadius = 5f;
    [SerializeField] protected float magnaticFieldTime = 10f;
    protected float magnaticFieldTimeCount = 0f;
    [SerializeField] protected float itemMovingSpeed = 0.1f;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    [SerializeField] protected Transform fx;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadSphereCollider(){
        if(this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.01f;
        Debug.LogWarning(transform.name + "LoadSphereCollider",gameObject);
    }

    protected virtual void LoadRigidbody(){
        if(this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.useGravity = false;
        this._rigidbody.isKinematic = true;
        Debug.LogWarning(transform.name + "LoadRigidbody",gameObject);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.delay = this.magneticCoolDown;
        this.timer = this.delay;
    }

    public override void Active(){
        if(!this.isReady) return;
        base.Active();
        this.TurnOnMagnaticField();
    }

    protected virtual void TurnOnMagnaticField(){
        this.sphereCollider.radius = this.magnaticFieldRadius;
        this.CreateFX();
        StartCoroutine(this.TimingMagnaticField());
    }

    protected virtual void TurnOffMagnaticField(){
        this.magnaticFieldTimeCount = 0;
        this.sphereCollider.radius = 0.01f;
        FXSpawner.Instance.Hold(this.fx);
    }

    protected IEnumerator TimingMagnaticField(){
        while(magnaticFieldTimeCount <= magnaticFieldTime){
            magnaticFieldTimeCount += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        this.TurnOffMagnaticField();
    }
    
    protected virtual void CreateFX(){
        Transform aOCTransform = this.abilities.AbilityObjectCtrl.transform;
        this.fx = FXSpawner.Instance.Spawn(FXSpawner.FX8, aOCTransform.position, aOCTransform.rotation );
        this.fx.gameObject.SetActive(true);
        this.fx.SetParent(aOCTransform);
    }

    protected virtual void OnTriggerEnter(Collider other){
        ItemPickupable itemPickupable = other.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;
        StartCoroutine(this.MovingItemToPlayer(other.transform.parent));
    }

    protected IEnumerator MovingItemToPlayer(Transform item){
        while(item.gameObject.activeSelf == true){
            Vector3 newPos = Vector3.Lerp(item.transform.position, this.abilities.AbilityObjectCtrl.transform.position, this.itemMovingSpeed);
            item.transform.position = newPos;
            yield return new WaitForFixedUpdate();
        }
    }
}
