using Interface;
using UnityEngine;

public class Module : MonoBehaviour, IDamagable
{
    public bool Destroyed => Health > 0;

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

    /*    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Bullet")) return;
            if (_hitCooldownTimer > 0) return;

            var bullet = collision.gameObject.GetComponent<BulletLaunch>();
            Health -= bullet.Damage;

            _hitCooldownTimer = HitCooldown;
        }
    */

    public void TakeDamage(int damage)
    {
        Health -= damage;
        _hitCooldownTimer = HitCooldown;
    }

    public void Destruct()
    {
    }
}
