using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ShootableObject", menuName = "SO/ShootableObject")]

public class ShootableObjectSO : ScriptableObject {
    public string ShootableObjectName = "Shootable Object";
    public ShootableObjectType shootableObjectType;
    public int hpMax = 2;
    public float radius = 0.19f;
    public float speed = 1f;
    public float shootingSpeed = 1f;
    public float collectItemsRating = 2f;
    public int attack = 1;
    public Sprite sprite;
    [Min(1)]
    public int score = 1;
    public int exp = 1;
    public List<ItemDropRate> dropList;
    public List<BuffDropRate> buffList;
}
