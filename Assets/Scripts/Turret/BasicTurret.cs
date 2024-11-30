using Interface;
using UnityEngine;

public class BasicTurret : MonoBehaviour, ITurret, IDamagable
{
    [Header("Turret Generator settings")]
    [SerializeField] private int _MaxHealth = 10;
    
    private Rigidbody2D _rb;
    private GameObject _mount;
    private Transform _mountTrans;
    private GameObject _cannon;
    private CannonShoot _cannonShoot;
    private Transform _cannonTrans;
    private int _currentHealth;

    private bool _powerField;
    
    private void Awake()
    {
        _currentHealth = _MaxHealth;
        _powerField = true;
        _rb = gameObject.GetComponent<Rigidbody2D>();

        _mountTrans = transform.Find("Mount");
        if (_mountTrans != null)
        {
            _mount = _mountTrans.gameObject;

            _cannonTrans = _mountTrans.Find("Cannon");

            if (_cannonTrans != null)
            {
                _cannon = _cannonTrans.gameObject;
            }
        }

        _cannonShoot = _cannon.GetComponent<CannonShoot>();
    }

    private void Start()
    {
        if (_mount == null || _cannon == null)
        {
            Debug.LogError("B");
        }
    }

    public void PowerFieldOff()
    {
        _powerField = false;
    }

    public void TakeDamage(int damage)
    {
        if (_currentHealth <= 0)
        {
            Destruct();
        }
        else if (!_powerField)
        {
            _currentHealth -= damage;
        }
    }

    public void Destruct()
    {
        _cannonShoot.isDestroyed = true;
        _cannonShoot.canShoot = false;
    }
}
