using System;
using Interface;
using UnityEngine;

public class MountTrack : MonoBehaviour
{
    private Transform _playerTrans;
    public bool destoryed = false;
    //[SerializeField] private float angleFix = 60f;
    [SerializeField] private bool mode;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _playerTrans = player.transform;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (destoryed) return;
        RotateTowardsPlayer();
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = _playerTrans.position - transform.position;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - (mode ? 160f : 90f);
        
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    
}
   
