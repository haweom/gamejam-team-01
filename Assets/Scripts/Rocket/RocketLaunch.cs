using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Interface;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RocketLaunch : MonoBehaviour
{
    [SerializeField] private int amountOfRockets;
    [SerializeField] private float lockRadius;
    
    [SerializeField] private GameObject rocketPrefab;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            LaunchRocket();
        }
    }


    private void LaunchRocket()
    {
        List<IDamagable> targets = new List<IDamagable>();
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, lockRadius);
        
        foreach (Collider2D collider in colliders)
        {
            IDamagable damagable = collider.GetComponent<IDamagable>();
            if (damagable != null && !collider.CompareTag("Player"))
            {
                targets.Add(damagable);
            }
        }
        
        int rocketsToLaunch = Mathf.Min(amountOfRockets, targets.Count);

        for (int i = 0; i < rocketsToLaunch; i++)
        {
            if (targets != null && targets.Count > 0)
            {
                IDamagable target = targets[i % targets.Count];

                if (target is MonoBehaviour monoTarget)
                {
                    Vector3 targetPosition = monoTarget.transform.position;
                    Vector2 direction = (targetPosition - transform.position).normalized;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                    
                    GameObject rocket = Instantiate(rocketPrefab, transform.position, Quaternion.Euler(0f, 0f, angle));
                    RocketFly rocketFly = rocket.GetComponent<RocketFly>();
                    StartCoroutine(StartRocket(rocketFly, i, targets));
                }
            }
        }
    }

    private IEnumerator StartRocket(RocketFly rocketFly, int index, List<IDamagable> targets)
    {
        yield return new WaitForSeconds(0.5f);
        rocketFly.FlyToTarget(targets[index]);
    }
}
