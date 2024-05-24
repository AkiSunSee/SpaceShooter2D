
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
public class HighScoreTable : AkiBehaviour
{
    private static HighScoreTable instance;
    public static HighScoreTable Instance => instance;
    [SerializeField] private Transform HighScoreContainer;
    [SerializeField] private Transform HighScoreTemplate;
    public List<HighScoreEntry> highScoreEntries;
    private List<Transform> highScoreEntryTransformList;
    string filePath;
    bool isOpen = false;

    protected override void Awake()
    {
        filePath = Path.Combine(Application.dataPath, "_Data/Resources", "highscores.json");
        PlayerPrefs.SetString("filePath",filePath);
        if(HighScoreTable.instance != null) Debug.LogError("Only 1 HighScoreTable allow to exist");
        HighScoreTable.instance = this;
        this.gameObject.SetActive(false);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHighScoreContainer();
        this.LoadHighScoreTemplate();
    }

    protected override void OnEnable() {
        base.OnEnable();
        this.LoadHighScoreEntries();
    }

    protected virtual void LoadHighScoreContainer(){
        if(this.HighScoreContainer != null) return;
        this.HighScoreContainer = transform.Find("HighScoreContainer");
        Debug.LogWarning(transform.name + ": HighScoreContainer",gameObject);
    }

    protected virtual void LoadHighScoreTemplate(){
        if(this.HighScoreTemplate != null) return;
        this.HighScoreTemplate = this.HighScoreContainer.Find("HighScoreTemplate");
        Debug.LogWarning(transform.name + ": LoadHighScoreTemplate",gameObject);
    }

    protected virtual void LoadHighScoreEntries(){
       if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            HighScoreList highScoreList = JsonUtility.FromJson<HighScoreList>(json);
            this.highScoreEntries = highScoreList.highScores;

            foreach (Transform child in HighScoreContainer)
            {
                if (child != HighScoreTemplate)
                {
                    Destroy(child.gameObject);
                }
            }

            highScoreEntryTransformList = new List<Transform>();
            foreach (HighScoreEntry highScoreEntry in this.highScoreEntries)
            {
                CreateHighScoreEntry(highScoreEntry, HighScoreContainer, highScoreEntryTransformList);
            }
        }
        else
        {
            Debug.LogWarning("HighScore file not found at " + filePath);
        }
    }

    private void CreateHighScoreEntry(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList){
        float templateHeight = this.HighScoreTemplate.GetComponent<RectTransform>().sizeDelta.y;
        Transform newScore = Instantiate(this.HighScoreTemplate, container);
        RectTransform newScoreRectTransform = newScore.GetComponent<RectTransform>();
        newScoreRectTransform.anchoredPosition = new Vector2(0, -templateHeight*transformList.Count);
        newScore.gameObject.SetActive(true);

        int rank = transformList.Count+1;
        string rankString;
        switch (rank) {
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
            default: rankString = rank+"TH"; break;
        }

        newScore.Find("posText").GetComponent<TextMeshProUGUI>().SetText(rankString);
        newScore.Find("scoreText").GetComponent<TextMeshProUGUI>().SetText(highScoreEntry.score.ToString());
        transformList.Add(newScore);
    }

    public string GetFilePath(){
        return this.filePath;
    }

    public void Toggle(){
        this.isOpen = !this.isOpen;
        this.gameObject.SetActive(this.isOpen);
    }
}
