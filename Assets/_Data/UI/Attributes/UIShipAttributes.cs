using UnityEngine;

public class UIShipAttributes : AkiBehaviour
{
    private static UIShipAttributes instance;
    public static UIShipAttributes Instance => instance;
    private bool isOpen = false;

    [SerializeField] public TextSkillPoint textSkillPoint;
    [SerializeField] protected UIAttributes uIAttributes;

    protected override void Awake()
    {
        base.Awake();
        if(UIShipAttributes.instance != null) Debug.LogError("Only 1 UIHotKeyCtrl can exist");
        UIShipAttributes.instance = this;
    }

    protected override void Start() {
        this.gameObject.SetActive(false);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextSkillPoint();
        this.LoadUIAttributes();
    }

    protected virtual void LoadTextSkillPoint(){
        if(this.textSkillPoint!= null) return;
        this.textSkillPoint = GetComponentInChildren<TextSkillPoint>();
        Debug.LogWarning(transform.name+" LoadTextSkillPoint",gameObject);
    }

    protected virtual void LoadUIAttributes(){
        if(this.uIAttributes!= null) return;
        this.uIAttributes = GetComponentInChildren<UIAttributes>();
        Debug.LogWarning(transform.name+" LoadUIAttributes",gameObject);
    }

    public virtual void Toggle(){
        if(!this.isOpen){
            this.gameObject.SetActive(true);
            this.uIAttributes.ShowAttributes();
            Time.timeScale = 0;
        }
        else{
            this.gameObject.SetActive(false);
            Time.timeScale =1;
        }
        this.isOpen = !this.isOpen;
    }
    
}
