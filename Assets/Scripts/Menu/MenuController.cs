using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Application = UnityEngine.WSA.Application;

public class MenuController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject ControllsMenu;
    
    public void MainMenuOnPlayButtonPressed()
    {
        Debug.Log("Load Game");
        SceneManager.LoadScene("MainLevel", LoadSceneMode.Single);
    }

    public void MainMenuOnControllsButtonPressed()
    {
        ControllsMenu.SetActive(true);
        MainMenu.SetActive(false);
        Debug.Log("Controlls button pressed");
    }

    public void MainMenuOnCreditsButtonPressed()
    {
        Debug.Log("cREDIST button pressed");
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
