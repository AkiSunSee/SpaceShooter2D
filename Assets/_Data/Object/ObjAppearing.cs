using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjAppearing : AkiBehaviour
{
    [Header("Obj Appearing")]
    [SerializeField] protected bool isAppearing = false;
    public bool IsAppearing => isAppearing;

    [SerializeField] protected bool appeared = false;
    public bool Appeared => appeared;

    [SerializeField] protected List<IObjAppearObserver> observer = new List<IObjAppearObserver>();

    protected override void Start(){
        base.Start();
        this.OnAppearStart();
    }
    protected virtual void FixedUpdate(){
        this.Appearing();
    }

    protected abstract void Appearing();

    public virtual void Appear(){
        this.appeared = true;
        this.isAppearing = false;
        this.OnAppearFinish();
    }

    public virtual void AddObserver(IObjAppearObserver observer){
        this.observer.Add(observer);
    }

    public virtual void RemoveObserver(IObjAppearObserver observer){
        this.observer.Remove(observer);
    }

    protected virtual void OnAppearStart(){
        foreach (IObjAppearObserver observer in this.observer)
        {
            observer.OnAppearStart();
        }
    }

    protected virtual void OnAppearFinish(){
        foreach (IObjAppearObserver observer in this.observer)
        {
            observer.OnAppearFinish();
        }
    }
}
