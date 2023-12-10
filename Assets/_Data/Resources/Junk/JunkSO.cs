using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Junk", menuName = "SO/Junk")]
public class JunkSO : ScriptableObject {
    public string junkName = "Junk";
    public int hpMax = 2;
    public float radius = 0.19f;
    public List<DropRate> dropList;
}
