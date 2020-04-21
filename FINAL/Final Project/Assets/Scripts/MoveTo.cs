// MoveTo.cs
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    NavMeshAgent agent;
    float distance;
    public Transform target;
    public Transform goal;
    public Transform goal2;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    void Update()
    {

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        Vector3 targetDir = target.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        if (angle < 5.0f)
        {
            print("close");


            if (distance <= 30)
            {
                agent.destination = goal.position;
            }
        }
    }
}