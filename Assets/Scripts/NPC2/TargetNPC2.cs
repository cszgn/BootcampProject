using UnityEngine;
using UnityEngine.AI;

public class TargetNPC2 : MonoBehaviour
{
    public NavMeshAgent agent;

    private Vector2 destinationVector;

    private float destinationX;
    private float destinationZ;


    void Start()
    {
        SetDestination();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, destinationVector) < 3)
        {
            SetDestination();
        }
    }

    private void SetDestination()
    {
        destinationX = Random.Range(-10f, 20.0f);
        destinationZ = Random.Range(-1f, 28f);

        destinationVector = new Vector3(destinationX, transform.position.y, destinationZ);

        agent.SetDestination(destinationVector);
    }

    public void AgentStop()
    {
        agent.speed = 0;
    }

    public void AgentContiue()
    {
        agent.speed = 1;
        SetDestination();
    }
}
