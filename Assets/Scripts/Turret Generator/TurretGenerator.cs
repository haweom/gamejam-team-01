using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class TurretGenerator : MonoBehaviour, IDamagable
{
    [Header("Turrets")]
    [SerializeField] private GameObject _turret1;
    [SerializeField] private GameObject _turret2;
    [SerializeField] private GameObject _turret3;

    private ITurret _iturret1;
    private ITurret _iturret2;
    private ITurret _iturret3;
    
    [Header("Turret Generator settings")]
    [SerializeField] private int _MaxHealth = 10;

    private int _currentHealth;

    private void Awake()
    {
        _iturret1 = _turret1.GetComponent<ITurret>();
        _iturret2 = _turret2.GetComponent<ITurret>();
        _iturret3 = _turret3.GetComponent<ITurret>();
    }

    public void TakeDamage(int damage)
    {
        if (_currentHealth <= 0)
        {
            Destruct();
        }
        else
        {
            _currentHealth -= damage;
        }
    }

    public void Destruct()
    {
        //TODO: Change sprite
        if(_turret1 != null) _iturret1.PowerFieldOff();
        if(_turret2 != null) _iturret2.PowerFieldOff();
        if(_turret3 != null) _iturret3.PowerFieldOff();
    }
}
