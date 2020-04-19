// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Patrol : MonoBehaviour
{

    GameObject[] Players;

    public Transform sight;
    bool CanSee;
    float Range = 100;

    bool chasing;
    public Transform target;
    float distance;
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public Transform goal;
    float angle;


    void Start()
    {
        Players = GameObject.FindGameObjectsWithTag("VRPlayer");
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {


        RaycastHit hit;
        if (Physics.Raycast(transform.Find("EYES").transform.position, transform.Find("EYES").transform.forward * Range, out hit, Range))
        {
            if (hit.transform.tag == "VRPlayer")
            {
                CanSee = true;
                Debug.Log("seeeeee");
            }
            else
            {
                CanSee = false;
                Debug.Log("wort");
            }
        }

        //checks for player
        Vector3 targetDir = target.position - transform.position;
        angle = Vector3.Angle(targetDir, transform.forward);
        distance = Vector3.Distance(target.position, this.transform.position);


        if (!CanSee)
        {
            if (chasing == true)
            {
                GotoNextPoint();
                chasing = false;
            }
            else
            {
                // Choose the next destination point when the agent gets
                // close to the current one.
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    GotoNextPoint();
            }
        }

        if (CanSee)
        {
            Debug.Log("see it");
            if (distance < 20)
            {
                Debug.Log("chasing");
                chasing = true;
                agent.destination = goal.position;
            }
            if (distance < 2)
            {
                Debug.Log("killed");
                GotoNextPoint();
                chasing = false;
            }
            else
            {
                // Choose the next destination point when the agent gets
                // close to the current one.
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    GotoNextPoint();
            }
        }
    }
}