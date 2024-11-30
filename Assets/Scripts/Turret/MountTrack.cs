using UnityEngine;

public class CannonTracking : MonoBehaviour
{
    private Transform _playerTrans;

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
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
   
