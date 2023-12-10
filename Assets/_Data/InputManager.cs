using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }

    [SerializeField] private Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos {get => mouseWorldPos;}

    [SerializeField] protected float isRightMouseDown;
    public float IsRightMouseDown {get => isRightMouseDown;}
    private void Awake() {
        if(InputManager.instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.instance = this;
    }
    private void Update() {
        this.checkMouseDown();
    }
    void FixedUpdate() {
        this.GetMousePos();
    }
    protected virtual void checkMouseDown(){
        this.isRightMouseDown = Input.GetAxis("Fire1");
    }
    protected virtual void GetMousePos(){
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
