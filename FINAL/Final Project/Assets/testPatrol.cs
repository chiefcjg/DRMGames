
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class testPatrol : MonoBehaviour
{

    public Transform target;
    float distance;
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public Transform goal;
    float angle;


    void Start()
    {
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
        Vector3 targetDir = target.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        if (angle < 125.0f)
        {
            if (Vector3.Distance(target.position, this.transform.position) < 5)
            {
                Vector3 direction = target.position - this.transform.position;
                direction.y = 0;

                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

                if (direction.magnitude > 2.6)
                {
                    agent.SetDestination(target.position);
                    Debug.Log("closing");
                }
            }
        }
        else
        {
            agent.isStopped = true;
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
            Debug.Log("leaving");
        }
    }
}