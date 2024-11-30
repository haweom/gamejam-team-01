using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class engineModule : MonoBehaviour, IDamagable
{
    [SerializeField] private SpriteRenderer engineSprite;
    [SerializeField] private SpriteRenderer fireSprite;
    [SerializeField] private Light2D engineLight;
    [SerializeField] private GameObject blowUpEffect;
    [SerializeField] private CircleCollider2D engineCollider;

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
        if (engineSprite.enabled == false && Health > 0)
        {
            repairEffect();
        }
    }

    //TODO add negative buffs
    
    private void damageEffect()
    {
        engineCollider.enabled = false;
        engineSprite.enabled = false;
        fireSprite.enabled = false;
        engineLight.enabled = false;
        Instantiate(blowUpEffect, transform.position, Quaternion.identity);
    }
    private void repairEffect()
    {
        engineCollider.enabled = true;
        engineSprite.enabled = true;
        fireSprite.enabled = true;
        engineLight.enabled = true;
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
