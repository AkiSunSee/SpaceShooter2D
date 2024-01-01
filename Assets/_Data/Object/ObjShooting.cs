using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjShooting : AkiBehaviour
{
    [SerializeField] protected bool shooting = false;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 1f;

    private void Update() {
        this.IsShooting();
    }
    private void FixedUpdate() {
        this.Shooting();
    }

    protected abstract bool IsShooting();

    protected virtual void Shooting(){
        this.shootTimer += Time.fixedDeltaTime;
        if(this.shootTimer < shootDelay) return;
        if(!IsShooting()) return;
        //if(InputManager.Instance.IsRightMouseDown == 0) return;
        Vector3 spawnPos = transform.parent.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.Bullet1, spawnPos, rotation);
        if(newBullet == null) return;
        newBullet.gameObject.SetActive(true);
        this.shootTimer = 0;
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);
    }
}
