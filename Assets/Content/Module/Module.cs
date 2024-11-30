using UnityEngine;

public class Module : MonoBehaviour
{
    public int Health = 100;
    private int _health;

    void Start()
    {
        _health = Health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
