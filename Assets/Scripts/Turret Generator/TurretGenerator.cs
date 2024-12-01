using Interface;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TurretGenerator : MonoBehaviour, IDamagable
{
    [Header("Turrets")]
    [SerializeField] private GameObject _turret1;
    [SerializeField] private GameObject _turret2;
    [SerializeField] private GameObject _turret3;
    
    [Header("Generator towers")]
    [SerializeField] private GameObject _tower1;
    [SerializeField] private Light2D _tower1Light;
    [SerializeField] private GameObject _tower2;
    [SerializeField] private Light2D _tower2Light;
    
    private Animator _animatorTower1;
    private Animator _animatorTower2;


    private ITurret _iturret1;
    private ITurret _iturret2;
    private ITurret _iturret3;
    
    [Header("Turret Generator settings")]
    [SerializeField] private int _MaxHealth = 10;

    private int _currentHealth;

    private void Awake()
    {
        if(_turret1 != null) _iturret1 = _turret1.GetComponent<ITurret>();
        if(_turret2 != null) _iturret2 = _turret2.GetComponent<ITurret>();
        if(_turret3 != null) _iturret3 = _turret3.GetComponent<ITurret>();
        _animatorTower1 = _tower1.GetComponent<Animator>();
        _animatorTower2 = _tower2.GetComponent<Animator>();
        _currentHealth = _MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Taking damage Generator");
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
        gameObject.GetComponent<Collider2D>().enabled = false;
        _animatorTower1.SetTrigger("Destroyed");
        _animatorTower2.SetTrigger("Destroyed");
        _tower1Light.intensity = 0;
        _tower2Light.intensity = 0;
        
        if(_turret1 != null) _iturret1.PowerFieldOff();
        if(_turret2 != null) _iturret2.PowerFieldOff();
        if(_turret3 != null) _iturret3.PowerFieldOff();
    }
}
