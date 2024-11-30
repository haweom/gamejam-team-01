using UnityEngine;

public class Module : MonoBehaviour
{
    public bool Usable { get; private set; } = true;

    public int Health = 4;
    private int _health;

    void Start()
    {
        _health = Health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Bullet")) return;

        var bullet = collision.gameObject.GetComponent<BulletLaunch>();
        _health -= bullet.Damage;
    }
}
