using UnityEngine;

public class LevelManager : AkiBehaviour
{
    [Header("Level")]
    public LevelData[] levels;
    private static LevelManager instance;
    public static LevelManager Instance { get => instance; }

    [SerializeField] protected int currentLevel=1;
    [SerializeField] protected int exp=0;
    [SerializeField] protected int skillpoint=0;

    protected override void Awake() {
        if(LevelManager.instance != null) Debug.LogError("Only 1 LevelManager allow to exist");
        LevelManager.instance = this;
    }

    protected virtual void LevelSet(int newLevel){
        this.currentLevel = newLevel;
    }

    public int GetExpRequired(int level) {
        foreach (LevelData lvl in levels) {
            if (lvl.level == level) {
                return lvl.expRequired;
            }
        }
        return -1;
    }

    protected void IncreaseLevelIfEnoughExp() {
        int expNeeded = GetExpRequired(this.currentLevel+1);
        if (expNeeded != -1 && this.exp >= expNeeded) {
            this.currentLevel++;
            this.skillpoint++;
            UIShipAttributes.Instance.textSkillPoint.UpdateText(skillpoint);
            this.exp-=expNeeded;
            TextLevel.Instance.UpdateText(currentLevel);
        } else {
            return;
        }
    }

    public virtual void GainExp(int exp){
        this.exp+=exp;
        this.IncreaseLevelIfEnoughExp();
    }

    public int GetSkillPoint(){
        return this.skillpoint;
    }

    public virtual bool HavingSkillPoint(){
        return this.skillpoint>0;
    }

    public virtual void UsingSkillPoint(){
        this.skillpoint--;
        UIShipAttributes.Instance.textSkillPoint.UpdateText(skillpoint);
    }
}
