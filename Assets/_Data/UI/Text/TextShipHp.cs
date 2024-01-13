using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShipHp : BaseText
{
    protected virtual void FixedUpdate() {
        this.UpdateShipHp();
    }

    protected virtual void UpdateShipHp(){
        int hpMax = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HpMax;
        int hp = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HP;
        this.text.SetText(hp +" / "+hpMax);
    }
}
