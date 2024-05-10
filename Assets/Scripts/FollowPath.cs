using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPath : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] goals;
    private int currentGoal;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
        Path();
    }

    private void Path()
    {
        if(agent.remainingDistance - agent.stoppingDistance == 0 && !agent.pathPending)
        {
            currentGoal++;
        }
        if(currentGoal == goals.Length)
        {
            currentGoal = 0;
        }

        agent.SetDestination(goals[currentGoal].position);
    }
}
