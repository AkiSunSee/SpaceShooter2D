using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : AkiBehaviour
{
    [SerializeField] private Transform model;
    public Transform Model {get => model;}

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn {get => junkDespawn;}

    [SerializeField] protected ShootableObjectSO shootableObjectSO;
    public ShootableObjectSO ShootableObjectSO {get => shootableObjectSO;}

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
        this.LoadShootableObjectSO();
    }

    protected virtual void LoadModel(){
        if(this.model != null) return;
        this.model = transform.Find("model");
        Debug.LogWarning(transform.name+": LoadModel",gameObject);
    }

    protected virtual void LoadJunkDespawn(){
        if(this.junkDespawn != null) return;
        this.junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
        Debug.LogWarning(transform.name+": LoadJunkDespawn",gameObject);
    }

    protected virtual void LoadShootableObjectSO(){
        if(this.shootableObjectSO != null) return;
        string resPath = "ShootableObject/Junk/"+ transform.name;
        this.shootableObjectSO = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name+ " "+ resPath +": LoadShootableObjectSO",gameObject);
    }
}
