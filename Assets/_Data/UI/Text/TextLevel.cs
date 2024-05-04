using UnityEngine;
using UnityEngine.EventSystems;


public class TextLevel : BaseText, IPointerClickHandler
{
    private static TextLevel instance;
    public static TextLevel Instance => instance;

    protected override void Awake(){
        if(TextLevel.instance != null) Debug.LogError("Only 1 LevelManager allow to exist");
        TextLevel.instance = this;
    }
    public virtual void UpdateText(int level){
        this.text.SetText(level.ToString());
    }

    public void OnPointerClick(PointerEventData eventData){
        UIShipAttributes.Instance.Toggle();
    }
}