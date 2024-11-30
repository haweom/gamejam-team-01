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
        List<IDamagable> damagables = new List<IDamagable>();
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, AreaDamageRadius, Vector2.zero, 0, DamageLayerMask);

        foreach (RaycastHit2D hit in hits)
        {
            IDamagable damagable = hit.collider.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(Damage);
            }
        }

        Debug.DrawLine(transform.position, transform.position + (Vector3)Vector2.up * AreaDamageRadius, Color.red, 1f);
    }
}