using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : DropRateSpawner
{
    private static BuffSpawner _instance;
    public static BuffSpawner Instance => _instance;

    protected override void Awake() {
        base.Awake();
        if(BuffSpawner._instance != null) Debug.LogError("Only 1 BuffSpawner allow to exist");
        BuffSpawner._instance = this;
    }

    public virtual List<BuffDropRate> Drop(List<BuffDropRate> dropList, Vector3 pos, Quaternion rot){
        List<BuffDropRate> dropBuffs = new List<BuffDropRate>();
        if(dropList.Count <1) return dropBuffs;

        dropBuffs = this.DropBuffs(dropList);
        foreach (BuffDropRate buff in dropBuffs)
        {
            BuffCode buffCode = buff.buffPSO.buffCode;
            Transform buffDrop = this.Spawn(buffCode.ToString(), this.RandomNearDropPos(pos), rot);
            if(buffDrop == null) continue;
            buffDrop.gameObject.SetActive(true);
        }

        return dropBuffs;
    }

    public virtual List<BuffDropRate> DropBuffs(List<BuffDropRate> buffs){
        List<BuffDropRate> droppedBuffs = new List<BuffDropRate>();
        float rate, buffRate;
        foreach (BuffDropRate buff in buffs)
        {
            rate = Random.Range(0,1f) * 100;
            buffRate = buff.dropRate/1000 * GameDropRate();  // if item.dropRate = 1000 equal 1%
            if(rate <= buffRate){
                droppedBuffs.Add(buff);
                break;
            }
        }
        return droppedBuffs;
    }
}
