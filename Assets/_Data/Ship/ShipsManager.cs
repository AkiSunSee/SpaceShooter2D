using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsManager : AkiBehaviour
{
    [SerializeField] protected List<ShipCtrl> ships = new List<ShipCtrl>();

    protected override void Start(){
        base.Start();
        //this.AddTestShip();
        this.SpawnShip();
    }

    protected virtual void AddTestShip(){
        Transform shipObj;

        shipObj = ShipSpawner.Instance.Spawn(ShipCode.Fighter);
        this.AddShip(shipObj);

        shipObj = ShipSpawner.Instance.Spawn(ShipCode.Healer);
        this.AddShip(shipObj);
        
        shipObj = ShipSpawner.Instance.Spawn(ShipCode.Miner);
        this.AddShip(shipObj);
        
        shipObj = ShipSpawner.Instance.Spawn(ShipCode.Tanker);
        this.AddShip(shipObj);
    }

    public virtual void AddShip(Transform obj){
        ShipCtrl ship= obj.GetComponent<ShipCtrl>();
        if(ship == null) return;
        this.ships.Add(ship);
    }

    public virtual void SpawnShip(){
        ShipCode shipCode = ShipCodeParser.FromString(GameCtrl.Instance.SelectedShipName);
        Transform ship = ShipSpawner.Instance.Spawn(shipCode);
        ship.gameObject.SetActive(true);
        this.SetCamareFollow(ship);
        this.SetGameData(ship);
    }

    protected virtual void SetCamareFollow(Transform ship){
        GameObject CameraHolder = GameObject.Find("CameraHolder");
        FollowTarget followTarget = CameraHolder.transform.GetComponent<FollowTarget>();
        followTarget.SetTarget(ship);
    }

    protected virtual void SetGameData(Transform ship){
        PlayerCtrl.Instance.SetCurrentShip(ship);
        ItemDropSpawner.Instance.SetPlayerDropRate(ship.GetComponent<ShipCtrl>().ShootableObjectSO.collectItemsRating);
    }
}
