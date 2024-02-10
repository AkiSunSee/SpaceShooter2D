using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffCtrl : AkiBehaviour
{
    [SerializeField] protected BuffDespawn buffDespawn;
    public BuffDespawn BuffDespawn => buffDespawn;

    [SerializeField] protected BuffProfileSO buffProfileSO;
    public BuffProfileSO BuffProfileSO => buffProfileSO;
    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadBuffDespawn();
        this.LoadBuffProfileSO();
    }

    protected virtual void LoadBuffDespawn(){
        if(this.buffDespawn != null) return;
        this.buffDespawn = transform.GetComponentInChildren<BuffDespawn>();
        Debug.Log(transform.name + " LoadBuffDespawn", gameObject);
    }

    protected virtual void LoadBuffProfileSO(){
        // if(this.buffProfileSO != null) return;
        BuffCode buffCode = BuffCodeParser.FromString(transform.name);
        BuffProfileSO buffProfileSO = BuffProfileSO.FindByBuffCode(buffCode);
        this.buffProfileSO = buffProfileSO;
    }

}


