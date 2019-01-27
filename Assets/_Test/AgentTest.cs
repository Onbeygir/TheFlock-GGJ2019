using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentTest : MonoBehaviour
{
    private NavMeshAgent _agent;
    public Transform TestTarget;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            _agent.SetDestination( TestTarget.position);
        }
    }

    public void SetDestinationTest()
    {
        _agent.destination = TestTarget.position;
    }
}
