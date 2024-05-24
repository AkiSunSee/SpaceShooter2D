using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : AkiBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance {get => instance;}
    [SerializeField] protected int score;
    public int Score => score;
    [SerializeField] protected TextScore textScore;
    [SerializeField] private List<HighScoreEntry> highScoreEntries;
    [SerializeField] private int maxHighScores = 5;
    protected override void Awake() {
        base.Awake();
        if (ScoreManager.instance != null) Debug.LogError("Only 1 ScoreManager allow to exist");
        ScoreManager.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextScore();
        this.LoadHighScoreEntries();
    }

    protected virtual void LoadTextScore(){
        if(this.textScore != null) return;
        this.textScore = GameObject.Find("TextScore").GetComponent<TextScore>();
        Debug.LogWarning(transform.name+": LoadTextScore",gameObject);
    }

    protected virtual void LoadHighScoreEntries(){
        string json = File.ReadAllText(PlayerPrefs.GetString("filePath"));
        HighScoreList highScoreList = JsonUtility.FromJson<HighScoreList>(json);
        this.highScoreEntries = highScoreList.highScores;
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

    public void AddNewScore()
    {
        this.highScoreEntries.Add(new HighScoreEntry { score = this.score });
        this.highScoreEntries.Sort((a, b) => b.score.CompareTo(a.score)); 

        if (this.highScoreEntries.Count > this.maxHighScores)
        {
            highScoreEntries.RemoveAt(highScoreEntries.Count - 1); // Loại bỏ điểm thấp nhất nếu vượt quá số lượng tối đa
        }

        this.SaveHighScores();
    }

    private void SaveHighScores()
    {
        HighScoreList highScoreList = new HighScoreList();
        highScoreList.highScores = this.highScoreEntries;

        string json = JsonUtility.ToJson(highScoreList, true);
        File.WriteAllText(PlayerPrefs.GetString("filePath"), json);
    }

}
