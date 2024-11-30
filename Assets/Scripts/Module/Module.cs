using UnityEngine;

public class Module : MonoBehaviour
{
    public bool Usable { get; private set; } = true;

    public int MaxHealth;
    public int Health { get; private set; }

    void Start()
    {
        Health = MaxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Bullet")) return;

        var bullet = collision.gameObject.GetComponent<BulletLaunch>();
        Health -= bullet.Damage;
    }
}
