using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private Transform gunOffset;

    [SerializeField]
    private float timeBetweenShots;

    private float lastFireTime;
    private bool fireContinously;
    private bool fireSingle;
    // Update is called once per frame
    void Update()
    {
        if (fireContinously || fireSingle)
        {
            float timeSinceLastFire = Time.time - lastFireTime;
            if (timeSinceLastFire >= timeBetweenShots)
            {
                FireBullet();
                lastFireTime = Time.time;
                fireSingle = false; // Reset single fire after shooting
            }
        }
    }

    private void OnAttack(InputValue inputValue)
    {
        fireContinously = inputValue.isPressed;
        if (inputValue.isPressed)
        {
            fireSingle = true;
        }
    }

    private void FireBullet()
    {
        
        
        // Convert screen position to world position
        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        GameObject bullet = Instantiate(bulletPrefab, gunOffset.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        
        // Calculate direction from player to mouse
        Vector2 direction = ((Vector2)mouseWorldPos - (Vector2)gunOffset.position).normalized;
        
        // Apply bullet speed in that direction
        rb.linearVelocity = direction * bulletSpeed;
    }
    } 

