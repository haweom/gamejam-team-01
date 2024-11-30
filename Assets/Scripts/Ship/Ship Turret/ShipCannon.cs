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
    
    private void Awake()
    {
        _shootPoint = transform.Find("ShootPoint");
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
            rb.AddForce(_shootPoint.up * shootForce, ForceMode2D.Impulse);
        }
    }
}
