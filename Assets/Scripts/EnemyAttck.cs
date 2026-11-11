using UnityEngine;

public class EnemyAttck : MonoBehaviour
{
    [SerializeField]
    private float damageAmount;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthController healthController = other.gameObject.GetComponent<HealthController>();
            if (healthController != null)
            {
                healthController.TakeDamaage(damageAmount);
            }
        }
    }
}
