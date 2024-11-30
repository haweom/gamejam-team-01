using System.Collections;
using Interface;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootForce = 10f;
    [SerializeField] private float shootInterval = 3f;
    [SerializeField] private int bulletCount = 4;
    [SerializeField] private bool isTurret;

    private float _shootTimer;
    private Transform _shootPoint;
    public bool isDestroyed;
    public bool canShoot;
    private bool isShooting;

    private void Awake()
    {
        _shootPoint = transform.Find("ShootPoint");
        isDestroyed = false;
        canShoot = true;
        isShooting = false;
    }

    private void Update()
    {
        if (!canShoot || isDestroyed) return;

        _shootTimer += Time.deltaTime;

        if (_shootTimer >= shootInterval)
        {
            if (!isTurret)
            {
                Shoot();
            }
            else if (!isShooting && isTurret)
            {
                StartCoroutine(ShootTurret());
            }

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

    private IEnumerator ShootTurret()
    {
        isShooting = true;
        
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
        
        isShooting = false;
    }

}
