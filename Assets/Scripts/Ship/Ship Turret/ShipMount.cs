using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMount : MonoBehaviour
{
    private Transform _playerTrans;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _playerTrans = player.transform;
    }

    private void Update()
    {
        RotateTowardsCursor();
    }

    private void RotateTowardsCursor()
    {
        Vector3 direction = _playerTrans.position - transform.position;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
