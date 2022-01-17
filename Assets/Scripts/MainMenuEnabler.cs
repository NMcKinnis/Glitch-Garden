using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEnabler : MonoBehaviour
{

    [SerializeField] Canvas mainMenuCanvas;
    string currentlyAtMainMenu;
    private void OptionsEnable()
    {

        currentlyAtMainMenu = SceneManager.GetActiveScene().ToString();
        if (currentlyAtMainMenu == "Start Screen")
        {
            mainMenuCanvas.gameObject.SetActive(true);
        }
        else
        {
            mainMenuCanvas.gameObject.SetActive(false);
        }


    }
}