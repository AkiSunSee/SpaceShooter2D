public class HealthBar : BarUI
{
    public virtual void SetValue(int newValue){
        var targetWidth = newValue * _maxRightMask/PlayerCtrl.Instance.CurrentShip.DamageReceiver.HpMax;
        var newRightMask = _maxRightMask + _initialRightMask - targetWidth;
        var padding = _mask.padding;
        padding.z = newRightMask;
        _mask.padding = padding;
    }

    public virtual void UpdateBarUI(){
        int hp = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HP;
        this.SetValue(hp);
    }

    protected virtual void FixedUpdate() {
        this.UpdateBarUI();
    }
}
