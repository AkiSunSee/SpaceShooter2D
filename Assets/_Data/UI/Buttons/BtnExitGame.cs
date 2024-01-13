using UnityEditor;
using UnityEngine;

public class BtnExitGame : BaseButton
{
    protected override void OnClick()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #endif
            Application.Quit();
    }
}
