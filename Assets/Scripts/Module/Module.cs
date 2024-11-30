using Interface;
using UnityEngine;

public class Module : MonoBehaviour, IDamagable
{
    [SerializeField] private ShipCannon shipCannon;
    [SerializeField] private SpriteRenderer cannonSprite;
    [SerializeField] private SpriteRenderer mountSprite;
    [SerializeField] private GameObject searchlight;
    [SerializeField] private GameObject blowUpEffect;

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

    private void damageEffect()
    {
        shipCannon.SetShootFalse();
        cannonSprite.enabled = false;
        mountSprite.enabled = false;
        searchlight.SetActive(false);
        Instantiate(blowUpEffect, transform.position, Quaternion.identity);
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
            damageEffect();
        }
    }

    public void Destruct()
    {
    }
}
