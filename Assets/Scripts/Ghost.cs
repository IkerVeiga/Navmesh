using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float distanceToFollowX;
    [SerializeField] private float distanceToFollowZ;

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
        followPlayer();
        Debug.Log(player.transform.position - this.transform.position);
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

    public void followPlayer()
    {
        if(((this.transform.position - player.transform.position).x <= distanceToFollowX) && ((this.transform.position - player.transform.position).z <= distanceToFollowZ))
        {
            agent.SetDestination(player.transform.position);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
