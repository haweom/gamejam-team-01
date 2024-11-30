using Interface;
using UnityEngine;

public class BulletLaunchShip : MonoBehaviour
{
    public int Damage = 1;
    public float AreaDamageRadius = 2f;
    public GameObject particlesPrefab;

    public LayerMask DamageLayerMask;

    private CameraController _cameraController;

    private void Awake()
    {
        _cameraController = Camera.main.GetComponent<CameraController>();
    }

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    private void OnDestroy()
    {
        Instantiate(particlesPrefab, transform.position, Quaternion.identity);
        _cameraController.Shake(0.3f, 0.93f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Turret"))
        {
            ApplyAreaDamage();
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground") || other.CompareTag("ForceFIeld"))
        {
            ApplyAreaDamage();
            Destroy(gameObject);
        }
    }

    private void ApplyAreaDamage()
    {
        //List<IDamagable> damagables = new List<IDamagable>();
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, AreaDamageRadius);

        foreach (Collider2D hit in hits)
        {
            IDamagable damagable = hit.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(Damage);
            }
        }
    }
}