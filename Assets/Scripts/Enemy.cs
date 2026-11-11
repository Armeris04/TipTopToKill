using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Transform target;

    NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; // Disable automatic rotation
        agent.updateUpAxis = false; // Disable automatic up axis adjustment
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}
