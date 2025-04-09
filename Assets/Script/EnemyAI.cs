using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 15f;
    private NavMeshAgent agent;
    private bool playerDetected = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (!playerDetected && distanceToPlayer <= detectionRange)
        {
            playerDetected = true;
        }

        if (playerDetected)
        {
            agent.SetDestination(player.position);
        }
    }

    public bool IsPlayerDetected()
    {
        return playerDetected;
    }
}
