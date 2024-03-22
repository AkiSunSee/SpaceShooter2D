using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class ItemStat
{
    public AttributesCode attribute;
    public bool isBuff;
    [Min(0)]
    public float percent =  0;
}
