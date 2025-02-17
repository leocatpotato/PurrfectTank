using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // 玩家目標
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform; // 自動尋找玩家
        }
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position); // 讓敵人移動到玩家位置
        }
    }
}
