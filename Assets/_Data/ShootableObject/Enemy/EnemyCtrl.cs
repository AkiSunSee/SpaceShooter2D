using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : AbilityObjectCtrl
{
    protected override string GetObjectTypeString(){
        return ShootableObjectType.Enemy.ToString();
    }

}
