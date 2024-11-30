using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class RocketFly : MonoBehaviour
{
    [SerializeField] private float rocketSpeed;
    [SerializeField] private float rocketDamage;
    
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
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
