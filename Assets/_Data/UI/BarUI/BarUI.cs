using UnityEngine;
using UnityEngine.UI;

public abstract class BarUI : AkiBehaviour
{
    [SerializeField] protected RectTransform _barRect;
    [SerializeField] protected RectMask2D _mask;

    protected float _maxRightMask;
    protected float _initialRightMask;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRectTransform();
        this.LoadRectMask2D();
    }
    protected override void Start()
    {
        base.Start();
        _maxRightMask = _barRect.rect.width - _mask.padding.x - _mask.padding.z;
        _initialRightMask = _mask.padding.z;

    }

    protected virtual void LoadRectTransform(){
        if(this._barRect != null) return;
        this._barRect = GetComponent<RectTransform>();
        Debug.LogWarning(transform.name + "LoadRectTransform",gameObject);
    }

    protected virtual void LoadRectMask2D(){
        if(this._mask != null) return;
        this._mask = GetComponent<RectMask2D>();
        Debug.LogWarning(transform.name + "LoadRectMask2D",gameObject);
    }
}
