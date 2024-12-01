using UnityEngine;

public class ForcedCameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Vector3 _direction;
    private FlyAway _shipScript;

    private void Awake()
    {
        var shipTrans = transform.Find("Ending Ship");
        var ship = shipTrans.gameObject;
        _shipScript = ship.GetComponent<FlyAway>();
    }

    private void Start()
    {
        _direction = new Vector3(1, 0.75f, 0).normalized;
    }

    private void Update()
    {
        if (transform.position.y >= 100f)
        {
            speed = 0f;
            _shipScript.UpUpAndAway();
        }
    }

    private void FixedUpdate()
    {
        transform.position += _direction * speed * Time.deltaTime;
    }
}
