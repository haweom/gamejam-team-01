using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float liftForce;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float antiGravityForce;
    
    //rotation
        [SerializeField] private float maxRotationAngle;
        [SerializeField] private float rotateForce;
        [SerializeField] private float stabilizationForce;
        
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
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * liftForce, ForceMode2D.Force);
        }
        else
        {
            rb.AddForce(Vector2.up * (antiGravityForce * _gravityForce), ForceMode2D.Force);
        }
        
        float horizontalInput = Input.GetAxis("Horizontal");
        
        if (horizontalInput != 0)
        {
            rb.AddTorque(-horizontalInput * rotateForce, ForceMode2D.Force);
        }
        
        RotationLimiter();
        //StabilizationForce();
        
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    private void RotationLimiter()
    {
        float currentAngle = rb.rotation;
        
        if (currentAngle > maxRotationAngle)
        {
            float overAngle = currentAngle - maxRotationAngle;

            rb.AddTorque(-overAngle * 0.5f, ForceMode2D.Force);
        }
         else if (currentAngle < -maxRotationAngle)
        {
            float overAngle = currentAngle + maxRotationAngle;
            rb.AddTorque(-overAngle * 0.5f, ForceMode2D.Force);
        }
    }



    /*private void StabilizationForce()
    {
        float currentAngle = rb.rotation;
        rb.AddTorque(-currentAngle * stabilizationForce, ForceMode2D.Force);
    }*/
}
