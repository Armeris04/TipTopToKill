using UnityEngine;

public class PlayerDamagedInvicibility : MonoBehaviour
{
    private InvicibilityController invicibilityController;

    [SerializeField]
    private float invicibilityDuration;
    private void Awake()
    {
        invicibilityController = GetComponent<InvicibilityController>();
    }
    public void StartInvincibility ()
    {
        invicibilityController.StartInvincibility(invicibilityDuration);
    }
}
