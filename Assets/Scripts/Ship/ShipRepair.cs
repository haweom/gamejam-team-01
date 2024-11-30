using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRepair : MonoBehaviour
{
    [SerializeField] private GameObject _shipTurret;
    [SerializeField] private GameObject _shipHull;
    [SerializeField] private GameObject _shipSmallEngine;
    [SerializeField] private GameObject _shipBigEngine;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //TODO:add Repair (OLAFFFFFFFFFFFFFFFF KURWAAAAAAAAAAAAAAAAAAAA)
        }
    }

}
