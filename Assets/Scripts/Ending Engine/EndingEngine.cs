using Interface;
using UnityEngine;

public class EndingEngine : MonoBehaviour, IDamagable
{
    [SerializeField] private int _MaxHealth = 10;
    [SerializeField] private GameObject _Gores;
    
    private int _currentHealth;
    
    public void Destruct()
    {
        // FX
        Instantiate(_Gores, transform.position, transform.rotation);

        Destroy(gameObject);
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
}
