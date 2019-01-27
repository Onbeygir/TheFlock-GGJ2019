using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : UnityEntity
{
    public SO_EnemyVehicleData Data;
    public SO_Party EnemyParty;

    private Health _health;

    private AIController _AIController;
    public AIController AICtrller
    {
        get
        {
            if (_AIController == null)
            {
                _AIController = GetComponent<AIController>();
            }

            return _AIController;
        }
    }
    private void Start()
    {
        _AIController = GetComponent<AIController>();
        if(_AIController != null)
        {
            EnemyParty.SubscribeVehicle(AICtrller);
        }
        
    }

    public void OnCreated(SO_EnemyVehicleData data, Vector3 direction)
    {
        Data = data;
        _health = GetComponent<Health>();
        if(_health)
        {
            _health.Setup(Data.MaxHealth, Data.MaxHealth);
        }
        AICtrller.AIFaction = Faction.Raider;
        StartCoroutine(MoveTowardsDirection(new Vector3(direction.x, 0f, direction.z)));
    }

    private IEnumerator MoveTowardsDirection(Vector3 direction)
    {
        float timePassed = 0;
        AICtrller.enabled = false;
        Vector3 startPos = transform.position;
        Vector3 target = startPos + direction;
        while (timePassed < 1f)
        {
            transform.position = Vector3.Lerp(startPos, target, timePassed);
            timePassed += Time.deltaTime;
            yield return null;
        }
        AICtrller.enabled = true;
    }
}
