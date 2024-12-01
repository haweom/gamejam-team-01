using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyAway : MonoBehaviour
{
    private Vector3 _direction;
    private float _speed = 0f;
    
    private void Start()
    {
        _direction = new Vector3(1, 0, 0).normalized;
    }
    
    public void UpUpAndAway()
    {
        Invoke(nameof(ChangeSpeed), 1f);
        Invoke(nameof(ReturnToMenu),3f);
    }

    private void ChangeSpeed()
    {
        _speed = 25f;
    }

    private void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void FixedUpdate()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }
}
