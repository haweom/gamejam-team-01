using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class HullModule : MonoBehaviour, IDamagable
{
    [SerializeField] private GameObject blowUpEffect;
    [SerializeField] private BoxCollider2D boxCollider;
    
    public int MaxHealth;
    public int Health { get; private set; }

    public float HitCooldown = 1.5f;
    private float _hitCooldownTimer;

    void Start()
    {
        Health = MaxHealth;
    }

    private void FixedUpdate()
    {
        if (_hitCooldownTimer > 0) _hitCooldownTimer -= Time.deltaTime;
    }

    private void Update()
    {
    }

    public void repairHealth()
    {
        Health = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (Health != 0)
        {
            Health -= damage;
        }
        _hitCooldownTimer = HitCooldown;

        if (Health <= 0)
        {
            Instantiate(blowUpEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void Destruct()
    {
    }
}
