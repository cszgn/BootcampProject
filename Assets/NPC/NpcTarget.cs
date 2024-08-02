using UnityEngine;
using UnityEngine.AI;

public class NpcTarget : MonoBehaviour
{
    public NavMeshAgent agent;

    private Vector3 destinationVector;

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
        float destinationX = Random.Range(-900.0f, 900.0f);
        float destinationZ = Random.Range(-820.0f, 820.0f);
        float destinationY = 0.0f; // Eğer y değeri sabitse, değiştirmeye gerek yok

        destinationVector = new Vector3(destinationX, destinationY, destinationZ);

        agent.SetDestination(destinationVector);
    }

    public void AgentStop()
    {
        agent.isStopped = true;
    }

    public void AgentContinue()
    {
        agent.isStopped = false;
        SetDestination();
    }
}
