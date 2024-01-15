using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : AkiBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }

    [SerializeField] private Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos {get => mouseWorldPos;}

    [SerializeField] protected float isRightMouseDown;
    public float IsRightMouseDown {get => isRightMouseDown;}

    protected Vector4 direction;
    public Vector4 Direction => direction;

    protected override void Awake() {
        if(InputManager.instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.instance = this;
    }
    private void Update() {
        this.checkMouseDown();
        this.GetKeyDown();
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

    protected virtual void GetDirectionByKeyDown(){
        this.direction.x = (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) ? 1 : 0;
        // this.direction.x = Input.GetKeyDown(KeyCode.A) ? 1 : 0;
        // if(this.direction.x == 0) this.direction.x = Input.GetKeyDown(KeyCode.LeftArrow) ? 1 : 0;
        this.direction.y = (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) ? 1 : 0;
        this.direction.z = (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) ? 1 : 0;
        this.direction.w = (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) ? 1 : 0;

        // if (this.direction.x == 1) Debug.Log("Left");
        // if (this.direction.y == 1) Debug.Log("Right");
        // if (this.direction.z == 1) Debug.Log("Up");
        // if (this.direction.w == 1) Debug.Log("Down");
    }

    protected virtual void GetKeyDown(){
        if(Input.GetKeyDown(KeyCode.I)){
            UIInventory.Instance.Toggle();
            return;
        }
        if(Input.GetKeyDown(KeyCode.R)){
            ItemInventoryDrop.Instance.Drop();
            return;
        }
        GetDirectionByKeyDown();
    }
}
