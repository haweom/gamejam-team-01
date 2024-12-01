using UnityEngine;

public class ShipMount : MonoBehaviour
{
    private Camera _mainCamera;
    private Transform _shipTransform;
    
    [SerializeField] private float rotationSpeed = 500f;
    [SerializeField] private float minAngle = -95f;
    [SerializeField] private float maxAngle = 95f;
    

    private void Awake()
    { 
        _mainCamera = Camera.main;
        _shipTransform = transform.parent.parent;
    }

    private void Update()
    {
        RotateTowardsCursor();
    }

    private void RotateTowardsCursor()
    {
        Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3 direction = mousePosition - transform.position;


        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        targetAngle = Mathf.Clamp(targetAngle, minAngle, maxAngle);
        float currentAngle = Mathf.DeltaAngle(0f, transform.rotation.eulerAngles.z);
        
        if (currentAngle < minAngle && targetAngle > currentAngle)
        {
            currentAngle = Mathf.MoveTowardsAngle(currentAngle, minAngle, rotationSpeed * Time.deltaTime);
        }
        else if (currentAngle > maxAngle && targetAngle < currentAngle)
        {
            currentAngle = Mathf.MoveTowardsAngle(currentAngle, maxAngle, rotationSpeed * Time.deltaTime);
        }
        else
        {
            currentAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
        }
        
        transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
    }
    
    private float NormalizeAngle(float angle)
    {
        while (angle > 180f) angle -= 360f;
        while (angle < -180f) angle += 360f;
        return angle;
    }
}
