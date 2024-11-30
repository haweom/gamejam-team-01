using UnityEngine;

public class BasicTurret : MonoBehaviour
{
    private Rigidbody2D _rb;
    private GameObject _mount;
    private GameObject _cannon;
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }
}
