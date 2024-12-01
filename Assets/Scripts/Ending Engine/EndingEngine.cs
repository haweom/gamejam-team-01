using Interface;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingEngine : MonoBehaviour, IDamagable
{
    [SerializeField] private int _MaxHealth = 5;
    [SerializeField] private GameObject _Gores;
    
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _MaxHealth;
    }

    public void Destruct()
    {
        // FX
        Instantiate(_Gores, transform.position, transform.rotation);

        Invoke(nameof(ChangeScene),2f);
        transform.localScale = new Vector3(0f, 0f, transform.localScale.z);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(2);
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
