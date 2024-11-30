using Interface;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlyingTurret : MonoBehaviour, ITurret, IDamagable
{
    [Header("Turrets")] 
    [SerializeField] private Light2D _lightFiled;

    [Header("Turret settings")]
    [SerializeField] private int _MaxHealth = 10;
    
    private Rigidbody2D _rb;
    private GameObject _mount;
    private MountTrack _mountTrack;
    private Transform _mountTrans;
    private GameObject _cannon;
    private CannonShoot _cannonShoot;
    private Transform _cannonTrans;
    private int _currentHealth;
    
    private void Awake()
    {
        _currentHealth = _MaxHealth;
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
        _mountTrack = _mountTrans.gameObject.GetComponent<MountTrack>();
    }

    private void Start()
    {
        if (_mount == null || _cannon == null)
        {
            Debug.LogError("B");
        }
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

    public void PowerFieldOff()
    {
        
    }

    public void Destruct()
    {
        _mountTrack.destoryed = true;
        _cannonShoot.isDestroyed = true;
        _cannonShoot.canShoot = false;
    }
}
