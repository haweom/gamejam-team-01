using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class ControllsMenuController : MonoBehaviour
    {
        public GameObject MainMenu;
        public GameObject ControllsMenu;
        
        public void ControllMenuOnBackButtonPressed()
        {
            ControllsMenu.SetActive(false);
            MainMenu.SetActive(true);
        }
    }
}