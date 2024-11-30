using UnityEngine;

public class Dieee : MonoBehaviour
{
    public float DyingTime;
    private float _time;

    private void Awake()
    {
        _time = DyingTime;
    }

    void Update()
    {
        _time -= Time.deltaTime;
        if (_time <= 0) Destroy(gameObject);
    }
}
