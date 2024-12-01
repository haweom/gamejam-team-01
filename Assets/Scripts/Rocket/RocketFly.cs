using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class RocketFly : MonoBehaviour
{
    [SerializeField] private float rocketSpeed;
    [SerializeField] private int rocketDamage;
    [SerializeField] private GameObject explosion;
    
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FlyToTarget(IDamagable target)
    {
        if (target is MonoBehaviour monoTarget)
        {
            Vector3 targetPosition = monoTarget.transform.position;
            Vector2 direction = (targetPosition - transform.position).normalized;
            
            rb.gravityScale = 0;
            rb.velocity = direction * rocketSpeed;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Turret"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            ApplyAreaDamage();
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground") || other.CompareTag("ForceFIeld"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            ApplyAreaDamage();
            Destroy(gameObject);
        }
    }
    private void ApplyAreaDamage()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 2);

        foreach (Collider2D hit in hits)
        {
            IDamagable damagable = hit.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(rocketDamage);
            }
        }
    }
}
