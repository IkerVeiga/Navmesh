using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    private NavMeshAgent agent;
    private int currentGoal;
    
    public Transform[] goals;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Path();
    }

    public void Path()
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

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
