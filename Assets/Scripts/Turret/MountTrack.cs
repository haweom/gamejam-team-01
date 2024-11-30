using System;
using Interface;
using UnityEngine;

public class MountTrack : MonoBehaviour
{
    private Transform _playerTrans;
    public bool destroyed = false;
    //[SerializeField] private float angleFix = 60f;
    [SerializeField] private bool mode;
    private float maxRange = 40f;
    private CannonShoot _cannonShoot;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _playerTrans = player.transform;

        var cannonTransform = transform.Find("Cannon");
        var cannon = cannonTransform.gameObject;
        _cannonShoot = cannon.GetComponent<CannonShoot>();
    }

    private void Start()
    {
        _cannonShoot.canShoot = false;
    }

    private void Update()
    {
        if (destroyed || _playerTrans == null) return;
        if (IsPlayerInRange())
        {
            if (!_cannonShoot.canShoot)
            {
                _cannonShoot.canShoot = true;
            }
            RotateTowardsPlayer();
        }
        else
        {
            _cannonShoot.canShoot = false;
        }
    }

    private bool IsPlayerInRange()
    {
        return Vector3.Distance(_playerTrans.position, transform.position) <= maxRange;
    }
    
    private void RotateTowardsPlayer()
    {
        Vector3 direction = _playerTrans.position - transform.position;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - (mode ? 160f : 90f);
        
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    
}
   
