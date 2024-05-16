using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Obstacle : MonoBehaviour
{
    private NavMeshAgent agent;
    private int currentGoal;

    public Transform[] goals;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (agent.remainingDistance - agent.stoppingDistance >= 0 && agent.remainingDistance - agent.stoppingDistance <= 0.2 && !agent.pathPending)
        {
            currentGoal++;
        }
        if (currentGoal == goals.Length)
        {
            currentGoal = 0;
        }
        agent.SetDestination(this.goals[currentGoal].position);
    }
}
