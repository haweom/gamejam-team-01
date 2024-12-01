using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float liftForce;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float antiGravityForce;
    [SerializeField] private float sideMovementForce;
    
    //rotation
    [SerializeField] private float maxRotationAngle;
    [SerializeField] private float rotateForce;
    [SerializeField] private float stabilizationForce;
    
    //ENGINE SPRITES
    [SerializeField] private SpriteRenderer bigEngineFire;
    [SerializeField] private SpriteRenderer smolEngineFire;
    [SerializeField] private Light2D smolEngine;
    [SerializeField] private Light2D bigEngine;
        
    private Rigidbody2D rb;
    private float _gravityForce;

    private void Awake()
    {
        
    }
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _gravityForce += rb.gravityScale * 9.81f;
    }


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * liftForce, ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.up * 0.5f * (antiGravityForce * _gravityForce), ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            bigEngine.enabled = false;
            smolEngine.enabled = false;
            bigEngineFire.enabled = false;
            smolEngineFire.enabled = false;
        }
        else
        {
            rb.AddForce(Vector2.up * (antiGravityForce * _gravityForce), ForceMode2D.Force);
            bigEngine.enabled = true;
            smolEngine.enabled = true;
            bigEngineFire.enabled = true;
            smolEngineFire.enabled = true;
        }
        
        float horizontalInput = Input.GetAxis("Horizontal");
        
        if (horizontalInput != 0)
        {
            rb.AddTorque(-horizontalInput * rotateForce, ForceMode2D.Force);
            rb.AddForce(Vector2.right * horizontalInput * sideMovementForce, ForceMode2D.Force);
        }
        
        RotationLimiter();
        
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
    
    private void RotationLimiter()
    {
        float currentAngle = rb.rotation;
        
        
        if (currentAngle <= maxRotationAngle && currentAngle >= -maxRotationAngle)
        {
            return;
        }
        
        float maxStrength = 2f;
        float stabilizingMultiplier = 0.5f;
        float brakingMultiplier = 0.8f;

        if (currentAngle > maxRotationAngle)
        {
            float overAngle = currentAngle - maxRotationAngle;
            float stabilizingForce = overAngle * stabilizingMultiplier;
            float brakingForce = -Mathf.Sign(currentAngle) * maxStrength * brakingMultiplier;
            rb.AddTorque(brakingForce + -stabilizingForce, ForceMode2D.Force);
        }
        else if (currentAngle < -maxRotationAngle)
        {
            float overAngle = currentAngle + maxRotationAngle;
            float stabilizingForce = overAngle * stabilizingMultiplier;
            float brakingForce = -Mathf.Sign(currentAngle) * maxStrength * brakingMultiplier;
            rb.AddTorque(brakingForce + -stabilizingForce, ForceMode2D.Force);
        }
    }
}
