using UnityEngine;

public class BulletLaunch : MonoBehaviour
{
    public int Damage = 10;

    private void Start()
    {
        Destroy(gameObject, 5);
    }
}
