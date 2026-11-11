using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementInput;

    [SerializeField] 
    private float moveSpeed = 5f;

    private Vector2 smoothMovementInput;
    private Vector2 movmentInputSmoothVelocity;

    private bool isFacingLeft = false;

    private Camera mainCamera;

    [SerializeField]
    private float screenBorder;
    private Animator animator;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        HandleSpriteOrientation();
        SetAnimtion();

    }

    private void SetAnimtion()
    {
        bool isMoving = movementInput != Vector2.zero;
        animator.SetBool("IsMoving", isMoving);
    
    }

    private void SetPlayerVelocity()
    {
        smoothMovementInput = Vector2.SmoothDamp(smoothMovementInput, movementInput, ref movmentInputSmoothVelocity, 0.1f);
        rb.linearVelocity = smoothMovementInput * moveSpeed;
        PreventPlayerFromMovingOffScreen();
        
    }

    private void PreventPlayerFromMovingOffScreen()
    {
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        
        if (screenPosition.x < screenBorder && rb.linearVelocity.x < 0 || screenPosition.x > mainCamera.pixelWidth - screenBorder && rb.linearVelocity.x > 0)
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }

        if (screenPosition.y < screenBorder && rb.linearVelocity.y < 0 || screenPosition.y > mainCamera.pixelHeight - screenBorder && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        }
        
    }

    private void HandleSpriteOrientation()
    {
        if (movementInput.x > 0 && !isFacingLeft)
        {
            Flip();
            
        }
        else if (movementInput.x < 0 && isFacingLeft)
        {
            Flip();
           
        }
    }

    private void Flip()
    {
        isFacingLeft = !isFacingLeft;
        if (movementInput != Vector2.zero)
        {

            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();

    }
}

