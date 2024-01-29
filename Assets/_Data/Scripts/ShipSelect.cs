using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShipSelect : BaseButton
{
    [SerializeField] protected ShootableObjectSO shootableObjectSO;
    [SerializeField] protected TextMeshProUGUI text;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectSO();
        this.LoadText();
    }

    protected virtual void LoadShootableObjectSO(){
        if(this.shootableObjectSO != null) return;
        string resPath = "ShootableObject/Ship/"+ transform.name;
        this.shootableObjectSO = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name+ " "+ resPath +": LoadShootableObjectSO",gameObject);
    }

    protected virtual void LoadText(){
        if(this.text != null) return;
        this.text = GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name +": LoadText",gameObject);
        this.LoadTextData();
    }

    protected virtual void LoadTextData(){
        int hp = this.shootableObjectSO.hpMax;
        this.text.SetText("Hp: "+hp);
    }

    protected override void OnClick()
    {
        PlayerPrefs.SetString("selectedShipName", transform.name);
        PlayerPrefs.Save();
        this.ChangeTextColor();
    }

    protected virtual void ChangeTextColor(){
        TextMeshProUGUI[] texts = transform.parent.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI text in texts)
        {
            text.color = Color.black;
        }
        this.text.color = Color.yellow;
    }
}
