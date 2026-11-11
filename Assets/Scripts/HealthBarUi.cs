using UnityEngine;

public class HealthBarUi : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image healthBarFillImage;
    public void UpdateHealthBar (HealthController healthController)
    {
    healthBarFillImage.fillAmount = healthController.RemainingHealthPercentage();
        
    }
}
