using Assets.Scripts;
using Interface;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HullModule : MonoBehaviour, IDamagable, IModule
{
    [SerializeField] private GameObject blowUpEffect;
    [SerializeField] private BoxCollider2D boxCollider;

    public int MaxHealth;
    public int Health { get; private set; }

    public float HitCooldown = 1.5f;
    private float _hitCooldownTimer;

    private RedOverlay _overlay;

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
    }

    public void repairHealth()
    {
        Health = MaxHealth;
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
            Instantiate(blowUpEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
