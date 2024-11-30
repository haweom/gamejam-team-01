using System;
using Interface;
using UnityEngine;

public class BulletLaunch : MonoBehaviour
{
    public int Damage = 1;

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.tag == "Turret")
        {
            other.GetComponent<IDamagable>().TakeDamage(Damage);
            Destroy(gameObject);
        }
        
        if (other.tag == "Ground")
        {
            Destroy(gameObject);
        }
        
    }
}
