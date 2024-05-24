using UnityEditor;
using UnityEngine;

public class BtnHighScoreTable : BaseButton
{
    protected override void OnClick()
    {
        if(HighScoreTable.Instance == null) return;
        HighScoreTable.Instance.Toggle();
    }
}
