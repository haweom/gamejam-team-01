using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRepair : MonoBehaviour
{
    [SerializeField] private Module _shipTurret;
    [SerializeField] private HullModule _shipHull;
    [SerializeField] private engineModule _shipSmallEngine;
    [SerializeField] private engineModule _shipBigEngine;

    private void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _shipHull.repairHealth();
            _shipTurret.repairHealth();
            _shipSmallEngine.repairHealth();
            _shipBigEngine.repairHealth();
        }
    }

}
