using System.Collections;
using Interface;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootForce = 10f;
    [SerializeField] private float shootInterval = 0.2f;
    [SerializeField] private int bulletCount = 4;

    private float _shootTimer;
    private Transform _shootPoint;
    public bool isDestroyed;
    public bool canShoot;
    private bool _isShooting;

    private void Awake()
    {
        _shootPoint = transform.Find("ShootPoint");
        isDestroyed = false;
        canShoot = true;
        _isShooting = false;
    }

    private void Update()
    {
        if (!canShoot || isDestroyed) return;
        
        if (!_isShooting)
        {
            StartCoroutine(ShootTurret());
        }
    }

    private IEnumerator ShootTurret()
    {
        _isShooting = true;
        
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, _shootPoint.position, _shootPoint.rotation);
            
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(_shootPoint.up * shootForce, ForceMode2D.Impulse);
            }
            
            yield return new WaitForSeconds(shootInterval);
        }
        yield return new WaitForSeconds(3f);
        
        _isShooting = false;
    }

}
