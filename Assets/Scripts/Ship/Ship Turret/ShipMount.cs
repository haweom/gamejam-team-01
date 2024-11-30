using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMount : MonoBehaviour
{
    private Camera _mainCamera;
    private Transform _shipTransform;
    
    [SerializeField] private float maxAngle = 95;
    [SerializeField] private float minAngle = -95f;
    

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
        
        float worldAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float shipAngle = _shipTransform.rotation.eulerAngles.z;
        float localAngle = worldAngle - shipAngle;
        localAngle = NormalizeAngle(localAngle);
        
        localAngle = Mathf.Clamp(localAngle, minAngle, maxAngle);
        
        transform.rotation = Quaternion.Euler(0f, 0f, localAngle + shipAngle);
    }
    
    private float NormalizeAngle(float angle)
    {
        while (angle > 180f) angle -= 360f;
        while (angle < -180f) angle += 360f;
        return angle;
    }
}
