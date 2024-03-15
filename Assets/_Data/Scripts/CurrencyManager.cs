using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : AkiBehaviour
{
    private static CurrencyManager instance;
    public static CurrencyManager Instance {get => instance;}

    [SerializeField] protected int currency;
    public int Currency => currency;

    protected override void Awake() {
        base.Awake();
        if (CurrencyManager.instance != null) Debug.LogError("Only 1 CurrencyManager allow to exist");
        CurrencyManager.instance = this;
    }

    public virtual void AddCurrency(int add){
        this.currency += add;
    }

    public virtual void DeductCurrency(int deduct){
        this.currency -= deduct;
    }

    public virtual bool HaveEnoughCurrency(int currency){
        return this.currency >= currency;
    }
}
