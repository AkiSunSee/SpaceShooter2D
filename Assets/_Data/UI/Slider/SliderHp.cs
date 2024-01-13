using UnityEngine;
using UnityEngine.UI;

public class SliderHp : BaseSlider
{
    [Header("Slider HP")]
    [SerializeField] protected float hpMax = 10;
    [SerializeField] protected float hp = 7;

    protected override void FixedUpdate() {
        this.ShowHP();
    }

    protected virtual void ShowHP(){
        float hpPercent = this.hp / this.hpMax;
        this.slider.value = hpPercent;
    }
    protected override void OnChanged(float newValue)
    {
       // Debug.Log(newValue);
    }

    public virtual void SetMaxHp(float maxHp){
        this.hpMax = maxHp;
    }

    public virtual void SetCurrentHp(float currentHp){
        this.hp = currentHp;
    }
}
