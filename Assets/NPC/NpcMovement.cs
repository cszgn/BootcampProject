using UnityEngine;
using UnityEngine.AI;

public class NpcMovement : MonoBehaviour
{
    public float wanderRadius = 10f; // NPC'nin yürüyeceği alanın yarıçapı
    public float wanderTimer = 5f; // NPC'nin yeni bir hedefe gitmeden önce bekleyeceği süre
    public Transform player; // Oyuncunun Transform bileşeni

    private NavMeshAgent agent;
    private float timer;
    private Animator animator; // NPC'nin animasyonlarını kontrol etmek için

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        timer = wanderTimer;
        SetNewDestination();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= wanderTimer)
        {
            SetNewDestination();
            timer = 0;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < 5f)
        {
            SetIdle();
        }
        else
        {
            SetWalking();
        }
    }

    void SetNewDestination()
    {
        Vector3 newPosition = RandomNavSphere(transform.position, wanderRadius, -1);
        agent.SetDestination(newPosition);
    }

    Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * distance;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, distance, layermask);
        return navHit.position;
    }

    void SetIdle()
    {
        agent.isStopped = true;
        animator.SetTrigger("Idle"); // Idle animasyonunu başlat
    }

    void SetWalking()
    {
        agent.isStopped = false;
        animator.SetTrigger("Walk"); // Yürüyüş animasyonunu başlat
    }

    public void ResumeMovement()
    {
        agent.isStopped = false;
        SetNewDestination();
    }
}
