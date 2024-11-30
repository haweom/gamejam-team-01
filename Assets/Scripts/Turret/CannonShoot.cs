using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootForce = 5f;
    [SerializeField] private float shootInterval = 0.5f;
    
    private float _shootTimer;
    private Transform _shootPoint;
    
    private void Awake()
    {
        _shootPoint = transform.Find("ShootPoint");
        
        if (_shootPoint == null)
        {
            Debug.LogError("ShootPoint not found");
        }
    }
    
    private void Update()
    {
        _shootTimer += Time.deltaTime;
        
        if (_shootTimer >= shootInterval)
        {
            Shoot();
            _shootTimer = 0f;
        }
    }
    
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, _shootPoint.position, _shootPoint.rotation);
        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(_shootPoint.up * shootForce, ForceMode2D.Impulse);
        }
    }
}
