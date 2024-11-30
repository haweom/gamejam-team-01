using Interface;
using UnityEngine;

public class MountTrack : MonoBehaviour
{
    private Transform _playerTrans;
    public bool destoryed = false;
    //[SerializeField] private float angleFix = 60f;
    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _playerTrans = player.transform;
    }

    private void Update()
    {
        if (destoryed) return;
        RotateTowardsPlayer();
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = _playerTrans.position - transform.position;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 160;
        
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    
}
   
