using UnityEngine;

public class BasicTurret : MonoBehaviour
{
    private Rigidbody2D _rb;
    private GameObject _mount;
    private Transform _mountTrans;
    private GameObject _cannon;
    private Transform _cannonTrans;
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();

        _mountTrans = transform.Find("Mount");
        if (_mountTrans != null)
        {
            _mount = _mountTrans.gameObject;

            _cannonTrans = _mountTrans.Find("Cannon");

            if (_cannonTrans != null)
            {
                _cannon = _cannonTrans.gameObject;
            }
        }
    }

    private void Start()
    {
        if (_mount == null || _cannon == null)
        {
            Debug.LogError("B");
        }
    }
}
