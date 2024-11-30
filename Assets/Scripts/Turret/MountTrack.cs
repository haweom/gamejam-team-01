using Interface;
using UnityEngine;

public class CannonTracking : MonoBehaviour
{
    private Transform _playerTrans;
    //[SerializeField] private float angleFix = 60f;
    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _playerTrans = player.transform;
    }

    private void Update()
    {
        RotateTowardsPlayer();
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = _playerTrans.position - transform.position;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 160;
        
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    
}
   
