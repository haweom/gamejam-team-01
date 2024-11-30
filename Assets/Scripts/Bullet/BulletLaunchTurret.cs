using System;
using Interface;
using UnityEngine;

public class BulletLaunchTurret : MonoBehaviour
{
    public int Damage = 1;

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Turret") )
        {
            Destroy(gameObject);
        }
        
        if (other.CompareTag("Ground") )
        {
            Destroy(gameObject);
        }
        
        if (other.CompareTag("Player"))
        {
            IDamagable damagable = other.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(Damage);
                Destroy(gameObject);
            }
        }
    }
}
