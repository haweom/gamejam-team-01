using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Application = UnityEngine.WSA.Application;

public class MenuController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject ControllsMenu;
    public GameObject Credits;

    private void Awake()
    {
        Credits.SetActive(false);
        ControllsMenu.SetActive(false);
    }

    public void MainMenuOnPlayButtonPressed()
    {
        Debug.Log("Load Game");
        SceneManager.LoadScene("MainLevel", LoadSceneMode.Single);
    }

    public void MainMenuOnControllsButtonPressed()
    {
        ControllsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void MainMenuOnCreditsButtonPressed()
    {
        Credits.SetActive(true);
        MainMenu.SetActive(false);
    }
    
    public void MainMenuOnExitButtonPressed()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
