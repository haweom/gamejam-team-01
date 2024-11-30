using UnityEngine;
using Random = UnityEngine.Random;

public class ShipCannon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject particlesPrefab;

    [SerializeField] private float shootForce = 10f;
    [SerializeField] private float shootInterval = 0.2f;
    [SerializeField] private float spreadAmount = 10f;

    private float _shootTimer;
    private Transform _shootPoint;
    private Rigidbody2D _shipRb;
    private CameraController _cameraController;
    private bool _canShoot = true;


    private void Awake()
    {
        _shootPoint = transform.Find("ShootPoint");
        _cameraController = Camera.main.GetComponent<CameraController>();
    }

    private void Start()
    {
        _shipRb = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        _shootTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && _shootTimer >= shootInterval && _canShoot)
        {
            Shoot();
            _shootTimer = 0f;
            _cameraController.Shake(0.1f, 0.9f);
        }
    }

    private void Shoot()
    {
        float spreadAngle = Random.Range(-spreadAmount, spreadAmount);
        Quaternion spreadRotation = Quaternion.Euler(0, 0, spreadAngle);

        Vector2 shootDirection = (spreadRotation * _shootPoint.up).normalized;

        GameObject bullet = Instantiate(bulletPrefab, _shootPoint.position, spreadRotation * _shootPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            float shipSpeed = Vector2.Dot(_shipRb.velocity, shootDirection);
            Vector2 additionalVelocity = shipSpeed > 0 ? shootDirection * shipSpeed : Vector2.zero;
            Vector2 bulletVelocity = (shootDirection * shootForce) + additionalVelocity;

            rb.velocity = bulletVelocity;
        }

        // FX
        Instantiate(particlesPrefab, _shootPoint.position, spreadRotation * _shootPoint.rotation);
    }

    public void SetShootTrue()
    {
        _canShoot = true;
    }

    public void SetShootFalse()
    {
        _canShoot = false;
    }
}