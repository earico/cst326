using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour {
    public Transform []agentDestinations;
    private NavMeshAgent agent;
    private int count;
    
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        count = 0;
    }

    void Update() {
        agent.destination = agentDestinations[count].transform.position;
        
        Debug.Log($"End position: {agent.pathEndPosition} - Current Pos: {agent.transform.position} - Status: {agent.pathStatus} ");

        if (count == 2) {
            //agent.nextPosition = agentDestinations[count++].transform.position;
            Debug.Log("next desination");
            count++;
        }
    }
}
