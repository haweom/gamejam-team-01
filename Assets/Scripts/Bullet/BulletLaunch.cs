using UnityEngine;

public class BulletLaunch : MonoBehaviour
{
    public int Damage = 1;

    private void Start()
    {
        Destroy(gameObject, 5);
    }
}
