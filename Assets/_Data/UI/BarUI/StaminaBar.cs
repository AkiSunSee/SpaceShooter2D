using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : BarUI
{
    public virtual void SetValue(float newValue, float maxValue){
        var targetWidth = newValue * _maxRightMask/maxValue;
        var newRightMask = _maxRightMask + _initialRightMask - targetWidth;
        var padding = _mask.padding;
        padding.z = newRightMask;
        _mask.padding = padding;
    }

    public virtual void UpdateBarUI(float currentvalue, float maxValue){
        this.SetValue(currentvalue, maxValue);
    }
}
