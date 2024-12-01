using Assets.Scripts;
using Interface;
using UnityEngine;

public class Module : MonoBehaviour, IDamagable, IModule
{
    [SerializeField] private ShipCannon shipCannon;
    [SerializeField] private SpriteRenderer cannonSprite;
    [SerializeField] private SpriteRenderer mountSprite;
    [SerializeField] private GameObject searchlight;
    [SerializeField] private GameObject blowUpEffect;
    [SerializeField] private CircleCollider2D circleCollider2D;

    private RedOverlay _overlay;

    public int MaxHealth;
    public int Health { get; private set; }

    public float HitCooldown = 1.5f;
    private float _hitCooldownTimer;

    void Awake()
    {
        _overlay = GameObject.Find("FlashImage").GetComponent<RedOverlay>();
    }

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
        if (cannonSprite.enabled == false && Health > 0)
        {
            repairEffect();
        }
    }

    public void repairHealth()
    {
        Health = MaxHealth;
    }

    private void damageEffect()
    {
        shipCannon.SetShootFalse();
        circleCollider2D.enabled = false;
        cannonSprite.enabled = false;
        mountSprite.enabled = false;
        searchlight.SetActive(false);
        Instantiate(blowUpEffect, transform.position, Quaternion.identity);
    }
    private void repairEffect()
    {
        shipCannon.SetShootTrue();
        circleCollider2D.enabled = true;
        cannonSprite.enabled = true;
        mountSprite.enabled = true;
        searchlight.SetActive(true);
    }

    public void TakeDamage(int damage)
    {
        _overlay.Flash();
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

    public float GetHealthPercent()
    {
        return (float)Health / MaxHealth;
    }
}
