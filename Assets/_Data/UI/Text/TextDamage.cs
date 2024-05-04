
using UnityEngine;
using TMPro;

public class TextDamage : AkiBehaviour
{
    [SerializeField] protected TextMeshProUGUI text;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadText();
    }

    protected virtual void LoadText(){
        if(this.text != null) return;
        this.text = GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name +": LoadText",gameObject);
    }

    public virtual void SetDamage(int damage){
        this.text.text = damage.ToString();
    }
}
