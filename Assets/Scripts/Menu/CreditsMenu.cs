using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Credits;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Credits.SetActive(false);
            MainMenu.SetActive(true);
        }
    }
}
