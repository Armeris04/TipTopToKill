using System.Data.Common;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float currentHealth;

    [SerializeField]
    private float maxHealth;

    public float RemainingHealthPercentage ()
    {
        return currentHealth / maxHealth;
    }

public bool IsInvincile { get; set; }

public UnityEvent OnDied;
public UnityEvent OnDamaged;
public UnityEvent OnHealthChanged;
public void TakeDamaage (float damageAmount)
    {
        if (currentHealth == 0)
        {
            return;
        }

        if (IsInvincile)
        {
            return;
        }

        currentHealth -= damageAmount;

        OnHealthChanged.Invoke();

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth == 0)
        {
            OnDied.Invoke();
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void Heal (float healAmount)
    {
        
        if (currentHealth == maxHealth)
        {
            return;
        }
        currentHealth += healAmount;
        OnHealthChanged.Invoke();

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    }
}
