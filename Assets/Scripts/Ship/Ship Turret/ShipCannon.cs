using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCannon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootForce = 10f;
    [SerializeField] private float shootInterval = 0.2f;
    
    private float _shootTimer;
    private Transform _shootPoint;
    private Rigidbody2D _shipRb;
    
    private void Awake()
    {
        _shootPoint = transform.Find("ShootPoint");
    }

    private void Start()
    {
        _shipRb = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        _shootTimer += Time.deltaTime;
        
        if (Input.GetMouseButton(0) && _shootTimer >= shootInterval)
        {
            Shoot();
            _shootTimer = 0f;
        }
    }
    
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, _shootPoint.position, _shootPoint.rotation);
        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 shootDirection = _shootPoint.up.normalized;
            float shipSpeed = Vector2.Dot(_shipRb.velocity, shootDirection);
            
            Vector2 additionalVelocity;
            if (shipSpeed > 0)
            {
                additionalVelocity = shootDirection * shipSpeed;
            }
            else
            {
                additionalVelocity = Vector2.zero;
            }
            
            Vector2 bulletVelocity = (shootDirection * shootForce) + additionalVelocity;
            
            rb.velocity = bulletVelocity;
        }
    }
}
