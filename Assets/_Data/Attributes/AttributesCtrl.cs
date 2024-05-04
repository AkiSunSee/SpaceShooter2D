using System;
using System.Collections.Generic;
using UnityEngine;
public class AttributesCtrl : AkiBehaviour{
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] public List<Attribute> attributes = new List<Attribute>();

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
        Dictionary<AttributesCode, float> attributeMap = new Dictionary<AttributesCode, float>{
            { AttributesCode.Attack, shootableObjectCtrl.ShootableObjectSO.attack },
            { AttributesCode.AttackSpeed, shootableObjectCtrl.ShootableObjectSO.shootingSpeed },
            { AttributesCode.Speed, shootableObjectCtrl.ShootableObjectSO.speed },
            { AttributesCode.Luck, shootableObjectCtrl.ShootableObjectSO.collectItemsRating }
        };

        bool missingAttri = false;
        foreach (Attribute attribute in attributes){
            if (attributeMap.ContainsKey(attribute.attributesCode)){
                float value = attributeMap[attribute.attributesCode];
                attribute.baseValue = value;
                attribute.currentValue = attribute.baseValue;
            } else {
                missingAttri = true;
            }
        }

        if (missingAttri) Debug.LogWarning($"{transform.name} LoadAttributes: You are missing attribute to load!!!", gameObject);
    }

    public virtual void AddAttributeValue(AttributesCode attributeCode, float addValue, bool isBase){
        Attribute attribute = this.GetAttributeByCode(attributeCode);
        if(isBase) attribute.AddBase(addValue);
        attribute.Add(addValue);
    }

    public virtual void DeductAttributeValue(AttributesCode attributeCode, float deductValue, bool isBase){
        Attribute attribute = this.GetAttributeByCode(attributeCode);
        if(isBase) attribute.DeductBase(deductValue);
        attribute.Deduct(deductValue);
    }

    public virtual Attribute GetAttributeByCode(AttributesCode attributeCode){
        return this.attributes.Find(x=> x.attributesCode == attributeCode);
    }
}