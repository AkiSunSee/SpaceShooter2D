
using UnityEngine;
using TMPro;

public abstract class BaseText : AkiBehaviour
{
    [Header("Base Text")]
    [SerializeField] protected TextMeshProUGUI text;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadText();
    }

    protected virtual void LoadText(){
        if(this.text != null) return;
        this.text = GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name +": LoadText",gameObject);
    }
    
}
