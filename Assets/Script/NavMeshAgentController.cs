using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentController : MonoBehaviour
{
    [SerializeField]
    GameObject targetObject;

    private NavMeshAgent navAgent;

    void Start()
    {
        navAgent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navAgent.SetDestination(targetObject.transform.position);
    }
}
