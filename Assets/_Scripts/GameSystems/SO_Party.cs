using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Party_", menuName = "Game/Create Party")]
public class SO_Party : ScriptableObject
{
    private List<AIController> _vehicles;
    public List<AIController> Vehicles { get {return _vehicles; } }
    public AIController[] VehiclesArray { get { return _vehicles.ToArray(); } }

    

    public void Init()
    {
        _vehicles = new List<AIController>();
    }

    public void SubscribeVehicle(AIController vehicle)
    {

        _vehicles.Add(vehicle);
    }

    public void UnsubscribeVehicle(AIController vehicle)
    {
       
        _vehicles.Remove(vehicle);   
    }

    public void CreateVehicle(UIResourceType vt)
    {
        switch (vt)
        {

            case UIResourceType.Repair:
                foreach (var item in Vehicles)
                {
                    Health h = item.GetComponent<Health>();
                    PlayerUnit pu = item.GetComponent<PlayerUnit>();
                    Debug.Log(h);
                    Debug.Log(pu);
                    h.UpdateHealth(pu.Data.MaxHealth);
                }
                break;
            case UIResourceType.Light:
                Instantiate(PlayerSpawner.Instance.LightVehiclePrefab);
                break;
            case UIResourceType.Medium:
                Instantiate(PlayerSpawner.Instance.MediumVehiclePrefab);
                break;
            case UIResourceType.Heavy:
                Instantiate(PlayerSpawner.Instance.HeavyVehiclePrefab);
                break;
            case UIResourceType.Power:
                break;
            default:
                break;
        }
    }


    public AIController GetClosestVehicle(Vector3 from)
    {
        float closest = float.PositiveInfinity;
        AIController temp = null;
        foreach (var item in Vehicles)
        {
            float dist = Vector3.Distance(from, item.transform.position);
            if (dist<closest)
            {
                closest = dist;
                temp = item;
            }
        }
        return temp;
    }
}
