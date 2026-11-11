using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class InvicibilityController : MonoBehaviour
{
    private HealthController healthController;

    private void Awake()
    {
        healthController = GetComponent<HealthController>();
    }

    public void StartInvincibility (float InvicibilityDuration)
    {
       StartCoroutine(InvincibilityCoroutine(InvicibilityDuration));
    }   

    private IEnumerator InvincibilityCoroutine (float InvicibilityDuration)
    {
        healthController.IsInvincile = true;

        yield return new WaitForSeconds(InvicibilityDuration);

        healthController.IsInvincile = false;
    }




}
