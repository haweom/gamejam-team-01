using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject flashPrefab;
    [SerializeField] private float shootForce = 10f;
    [SerializeField] private float shootInterval = 0.2f;

    private float _shootTimer;
    private Transform _shootPoint;

    private void Awake()
    {
        _shootPoint = transform.Find("ShootPoint");
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
        _ = Instantiate(flashPrefab, _shootPoint.position, _shootPoint.rotation);

        if (bullet.TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.AddForce(_shootPoint.up * shootForce, ForceMode2D.Impulse);
        }
    }
}
