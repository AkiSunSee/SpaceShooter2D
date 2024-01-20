using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHotKeyManager : AkiBehaviour
{
    private static InputHotKeyManager instance;
    public static InputHotKeyManager Instance { get => instance; }

    public bool isAlpha1 = false;
    public bool isAlpha2 = false;
    public bool isAlpha3 = false;
    public bool isAlpha4 = false;
    public bool isAlpha5 = false;
    public bool isAlpha6 = false;
    public bool isAlpha7 = false;

    protected override void Awake() {
        if(InputHotKeyManager.instance != null) Debug.LogError("Only 1 InputHotKeyManager allow to exist");
        InputHotKeyManager.instance = this;
    }
    private void Update() {
        this.GetHotKeyDown();
    }

    protected virtual void GetHotKeyDown(){
        isAlpha1 = Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1);
        isAlpha2 = Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2);
        isAlpha3 = Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3);
        isAlpha4 = Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4);
        isAlpha5 = Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5);
        isAlpha6 = Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6);
        isAlpha7 = Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7);
    }

}
