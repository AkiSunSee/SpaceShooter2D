using System;
using System.Collections.Generic;
using UnityEngine;
public class AttributesCtrl : AkiBehaviour{
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected List<Attribute> attributes = new List<Attribute>();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectCtrl();
        this.CreateAttributesList();
    }

    protected virtual void LoadShootableObjectCtrl(){
         if(this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.LogWarning(transform.name+": LoadShootableObjectCtrl",gameObject);
    }
    protected virtual void CreateAttributesList(){
        if(this.attributes.Count > 0) this.attributes.Clear();
        AttributesCode[] listAttributes = (AttributesCode[])Enum.GetValues(typeof(AttributesCode));
        for(int i=0; i< listAttributes.Length;i++){
            AttributesCode attributeCode = listAttributes[i];
            if(attributeCode != AttributesCode.NoAttributes){
                Attribute attribute = new Attribute{
                    attributesCode = attributeCode
                };
                this.attributes.Add(attribute);
            }
        }
        this.LoadAttributes();
    }

    protected virtual void LoadAttributes(){
        bool missingAttri = false;
        foreach (Attribute attribute in this.attributes)
        {
            if(attribute.attributesCode == AttributesCode.Attack){
                attribute.currentValue = this.shootableObjectCtrl.ShootableObjectSO.attack;
                continue;
            }
            if(attribute.attributesCode == AttributesCode.AttackSpeed){
                attribute.currentValue = this.shootableObjectCtrl.ShootableObjectSO.shootingSpeed;
                continue;
            }
            if(attribute.attributesCode == AttributesCode.Speed){
                attribute.currentValue = this.shootableObjectCtrl.ShootableObjectSO.speed;
                continue;
            }
            if(attribute.attributesCode == AttributesCode.Luck){
                attribute.currentValue = this.shootableObjectCtrl.ShootableObjectSO.collectItemsRating;
                continue;
            }
            missingAttri = true;
        }
        if(missingAttri) Debug.LogWarning(transform.name + "LoadAttributes: You are missing attribute to load!!!",gameObject);
    }

    public virtual void AddAttributeValue(AttributesCode attributeCode, float addValue){
        Attribute attribute = this.GetAttributeByCode(attributeCode);
        attribute.Add(addValue);
    }

    public virtual void DeductAttributeValue(AttributesCode attributeCode, float deductValue){
        Attribute attribute = this.GetAttributeByCode(attributeCode);
        attribute.Deduct(deductValue);
    }

    public virtual Attribute GetAttributeByCode(AttributesCode attributeCode){
        return this.attributes.Find(x=> x.attributesCode == attributeCode);
    }
}