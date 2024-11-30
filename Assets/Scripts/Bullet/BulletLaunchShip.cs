using System;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class BulletLaunchShip : MonoBehaviour
{
    public int Damage = 1;
    public float AreaDamageRadius = 2f;
    public LayerMask DamageLayerMask; 

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Turret"))
        {
            ApplyAreaDamage();
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground") || other.CompareTag("ForceFIeld"))
        {
            ApplyAreaDamage();
            Destroy(gameObject);
        }
    }

    private void ApplyAreaDamage()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, AreaDamageRadius);

        foreach (Collider2D hit in hits)
        {
            IDamagable damagable = hit.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(Damage);
            }
        }
    }
}