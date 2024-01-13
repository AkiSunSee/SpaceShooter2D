using UnityEngine;
using UnityEngine.UI;

public class HPBar : AkiBehaviour
{
    [Header("HP Bar")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;

    [SerializeField] protected SliderHp sliderHp;

    [SerializeField] protected Spawner spawner;
    
    [SerializeField] protected FollowTarget followTarget;

    protected virtual void FixedUpdate(){
        this.ShowHp();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlideHP();
        this.LoadFollowTarget();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner(){
        if(this.spawner != null) return;
        this.spawner = transform.parent?.parent?.GetComponent<Spawner>();
        Debug.LogWarning(transform.name+": LoadSpawner",gameObject);
    }

    protected virtual bool IsTargetDead(){
        return this.shootableObjectCtrl.DamageReceiver.IsDead();
    }

    protected virtual void LoadSlideHP(){
        if(this.sliderHp != null) return;
        this.sliderHp = transform.GetComponentInChildren<SliderHp>();
        Debug.LogWarning(transform.name+": LoadSliderHp",gameObject);
    }

    protected virtual void LoadFollowTarget(){
        if(this.followTarget != null) return;
        this.followTarget = transform.GetComponent<FollowTarget>();
        Debug.LogWarning(transform.name+": LoadFollowTarget",gameObject);
    }

    protected virtual void ShowHp(){
        if(this.shootableObjectCtrl==null) return;

        if(IsTargetDead()){
            this.spawner.Despawn(this.transform);
            return;
        }
        float hpMax = this.shootableObjectCtrl.DamageReceiver.HpMax;
        float hp = this.shootableObjectCtrl.DamageReceiver.HP;

        this.sliderHp.SetMaxHp(hpMax);
        this.sliderHp.SetCurrentHp(hp);
    }

    public virtual void SetShootableObjectCtrl(ShootableObjectCtrl shootableObjectCtrl){
        this.shootableObjectCtrl = shootableObjectCtrl;
    }
}
