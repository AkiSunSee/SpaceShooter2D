using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootableObject", menuName = "SO/ShootableObject")]

public class ShootableObjectSO : ScriptableObject {
    public string ShootableObjectName = "Shootable Object";
    public ShootableObjectType shootableObjectType;
    public int hpMax = 2;
    public float radius = 0.19f;
    public List<DropRate> dropList;
}
