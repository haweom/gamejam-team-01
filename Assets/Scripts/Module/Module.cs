using UnityEngine;

public class Module : MonoBehaviour
{
    public bool Usable;

    public int Health = 4;
    private int _health;

    void Start()
    {
        _health = Health;
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Bullet")) return;

        var bullet = collision.gameObject.GetComponent<BulletLaunch>();
        _health -= bullet.Damage;
    }
}
