using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }

    [SerializeField] private float playerAwarenessDistance = 5f;
    [SerializeField] private float wanderRadius = 4f;
    [SerializeField] private float changeDirectionCooldown = 3f;

    private Transform player;
    private NavMeshAgent agent;

    private float timer;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        AwareOfPlayer = distance <= playerAwarenessDistance;
        if (AwareOfPlayer)
        {
            ChasePlayer();
        }
        else
        {
            Wander();
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    void Wander()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f || !agent.hasPath)
        {
            Vector3 randomPoint = Random.insideUnitCircle * wanderRadius;
            randomPoint += transform.position;

            agent.SetDestination(randomPoint);

            timer = changeDirectionCooldown;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playerAwarenessDistance);

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, wanderRadius);
    }
}