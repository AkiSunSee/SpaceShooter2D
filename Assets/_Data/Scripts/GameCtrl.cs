using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : AkiBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance {get => instance;}
    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera {get => mainCamera;}

    [SerializeField] protected string selectedShipName;
    public string SelectedShipName => selectedShipName;

    [SerializeField] protected bool isGamePaused=false;

    protected override void Awake() {
        base.Awake();
        if (GameCtrl.instance != null) Debug.LogError("Only 1 GameCtrl allow to exist");
        GameCtrl.instance = this;
    }

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadCamera();
        this.LoadSelectedShipName();
    }

    protected virtual void LoadCamera(){
        if(this.mainCamera != null) return;
        this.mainCamera = GameCtrl.FindObjectOfType<Camera>();
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }

    protected virtual void LoadSelectedShipName(){
        this.selectedShipName = PlayerPrefs.GetString("selectedShipName", "Fighter");
    }

    public virtual void SetSelectedShipName(string str){
        this.selectedShipName = str;
    }

    public virtual void PauseGame(){
        this.isGamePaused = true;
        Time.timeScale = 0;
    }

    public virtual void UnPauseGame(){
        this.isGamePaused = false;
        Time.timeScale = 1;
    }

    public virtual bool IsGamePaused(){
        return this.isGamePaused;
    }
}
