using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : AkiBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance {get => instance;}

    [SerializeField] protected int score;
    public int Score => score;

    [SerializeField] protected TextScore textScore;

    protected override void Awake() {
        base.Awake();
        if (ScoreManager.instance != null) Debug.LogError("Only 1 ScoreManager allow to exist");
        ScoreManager.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextScore();
    }

    protected virtual void LoadTextScore(){
        if(this.textScore != null) return;
        this.textScore = GameObject.Find("TextScore").GetComponent<TextScore>();
        Debug.LogWarning(transform.name+": LoadTextScore",gameObject);
    }

    public virtual void AddScore(int add){
        this.score += add;
        this.UpdateScore();
    }

    public virtual void ResetScore(){
        this.score = 0;
        this.UpdateScore();
    }

    protected virtual void UpdateScore(){
        this.textScore.UpdateText(this.score);
    }
}
