using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuffProfileSO", menuName = "SO/BuffProfile")]
public class BuffProfileSO: ScriptableObject {
    public BuffCode buffCode = BuffCode.NoBuff;
    public string buffName = "no-name";

    [Range(1.5f, 3)]
    public float buffMultiplierValue = 1.5f;
    public Sprite sprite;

    [Range(5,60)]
    public float buffDuration = 5f;  

    public static BuffProfileSO FindByBuffCode(BuffCode buffCode){
        var profiles = Resources.LoadAll("BuffProfiles", typeof(BuffProfileSO));
        foreach(BuffProfileSO profile in profiles){
            if(profile.buffCode == buffCode) return profile;
        }
        return null;
    }
}
