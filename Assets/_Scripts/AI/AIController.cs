using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;


public class AIController : MonoBehaviour
{
    public enum AIState
    {
        Idle,
        Active,
        Dead
    }
    public SO_Brain Brain;
    public AIState State;

    public float AITickInterval = 0.166f;

    private NavMeshAgent _agent;

    public Faction AIFaction;
    public Weapon[] Weapons;
    public SpriteRenderer[] rends;

    private Vector3 _targetPosition;
    public Vector3 TargetPosition
    {
        set
        {
            if (_targetPosition != value)
            {
                _targetPosition = value;
                OnTargetPositionUpdated();
            }
            else
                _targetPosition = value;
        }
        get => _targetPosition;
    }

    private YieldInstruction _yieldInstruction;
    private UnityEntity _entity;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _yieldInstruction = new WaitForSeconds(AITickInterval);
        _entity = GetComponent<UnityEntity>();
        StartCoroutine(ZSorting());
    }
    private void Start()
    {
        foreach (var item in Weapons)
        {
            item.AIFaction = AIFaction;            
            item.StartWeapon();
            if(AIFaction == Faction.Raider)
            {
                var temp = (_entity as EnemyUnit);
                if(temp && temp.Data) item.ChangeDamage(temp.Data.DPS);
            }
            else
            {
                var temp = _entity as PlayerUnit;
                if(temp && temp.Data) item.ChangeDamage(temp.Data.DPS);
            }
            
        }
        if (AIFaction == Faction.Raider)
        {
            Debug.Log(name);
            State = AIState.Active;
            StartCoroutine(FSM());
            
        }
        
    }

    public IEnumerator FSM()
    {
        while(State == AIState.Active)
        {
            TargetPosition = Brain.DoThinking(this);
            yield return _yieldInstruction;
        }
        
    }
    
    IEnumerator ZSorting()
    {
        while(State == AIState.Active)
        {
            foreach (var rend in rends)
            {
                rend.sortingOrder = -((int)transform.position.z);
                
            }
            yield return _yieldInstruction;
        }
        
    }

    private void OnTargetPositionUpdated()
    {
        if(_agent != null)
            _agent.SetDestination(TargetPosition);
    }
}
