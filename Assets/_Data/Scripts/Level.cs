using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : AkiBehaviour
{
    [Header("Level")]
    [SerializeField] protected int currentLevel = 0;
    [SerializeField] protected int maxLevel = 99;

    public int CurrentLevel => currentLevel;
    public int MaxLevel => maxLevel;

    public virtual void LevelUp(){
        this.currentLevel++;
        this.LimitLevel();
    }

    public virtual void LevelSet(int newLevel){
        this.currentLevel = newLevel;
        this.LimitLevel();
    }

    protected virtual void LimitLevel(){
        if(this.currentLevel > this.maxLevel) this.currentLevel = this.maxLevel;
        if(this.currentLevel < 1) this.currentLevel =1;
    }
}
