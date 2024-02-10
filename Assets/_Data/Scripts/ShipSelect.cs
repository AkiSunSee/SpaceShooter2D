using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipSelect : BaseButton
{
    [SerializeField] protected ShootableObjectSO shootableObjectSO;
    [SerializeField] protected TextMeshProUGUI text;
    [SerializeField] protected Image image;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectSO();
        this.LoadImage();
        this.LoadText();
        this.LoadData();
    }

    protected virtual void LoadShootableObjectSO(){
        if(this.shootableObjectSO != null) return;
        string resPath = "ShootableObject/Ship/"+ transform.name;
        this.shootableObjectSO = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name+ " "+ resPath +": LoadShootableObjectSO",gameObject);
    }

    protected virtual void LoadImage(){
        if(this.image != null) return;
        this.image = GetComponent<Image>();
        Debug.LogWarning(transform.name+": LoadImage",gameObject);
    }

    protected virtual void LoadText(){
        if(this.text != null) return;
        this.text = GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name +": LoadText",gameObject);
    }

    protected virtual void LoadData(){
        this.LoadTextData();
        this.LoadImageData();
    }
    protected virtual void LoadTextData(){
        int hp = this.shootableObjectSO.hpMax;
        float speed = this.shootableObjectSO.speed;
        int atk = this.shootableObjectSO.attack;
        float rate= this.shootableObjectSO.collectItemsRating;
        float attackSpeed = this.shootableObjectSO.shootingSpeed;
        this.text.SetText("Attack: "+atk+"\nHp: "+hp+"\nSpeed: "+speed+"\nLuck: "+rate+"\nAtkSpeed: "+attackSpeed+"s/1");
    }

    protected virtual void LoadImageData(){
        this.image.sprite = this.shootableObjectSO.sprite;
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
