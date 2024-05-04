using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAttributes : AkiBehaviour
{
    [SerializeField] UIAttribute uiAttribute;
    [SerializeField] List<UIAttribute> attributes;
    [SerializeField] protected RectTransform rectTransform;

    protected override void Awake()
    {
        base.Awake();
        this.CreateAttribute();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIAttribute();
    }

    protected virtual void LoadUIAttribute(){
        if(this.uiAttribute != null) return;
        this.uiAttribute = GetComponentInChildren<UIAttribute>();
        this.rectTransform = GetComponent<RectTransform>();
        Debug.LogWarning(transform.name+" LoadUIAttribute",gameObject);
    }
    protected virtual void CreateAttribute(){
        float attributeHeight = this.rectTransform.sizeDelta.y;
        
        int index =0;
        Vector3 pos;
        foreach(AttributesCode code in System.Enum.GetValues(typeof(AttributesCode))){
            if (code == AttributesCode.NoAttributes) continue;
            UIAttribute newUIAttribute = Instantiate(this.uiAttribute, this.uiAttribute.transform.parent);
            newUIAttribute.name = this.uiAttribute.name;
            pos = newUIAttribute.transform.localPosition;
            pos.y = (index * attributeHeight)*-1;
            newUIAttribute.transform.localPosition = pos;
            this.attributes.Add(newUIAttribute);
            index++;
        }

        this.uiAttribute.gameObject.SetActive(false);
    }

    public virtual void ShowAttributes(){
        Attribute attribute;
        UIAttribute uIAttribute;
        for(int i=0;i<this.attributes.Count;i++){
            attribute = PlayerCtrl.Instance.CurrentShip.AttributesCtrl.attributes[i];
            uIAttribute = this.attributes[i];
            uIAttribute.SetAttribute(attribute);
        }
    }
}
