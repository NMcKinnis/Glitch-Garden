using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex;
    [SerializeField] int loadingScreenTimeInSeconds = 4;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            LoadStartMenu();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadStartMenu()
    {
        LoadFromStart();
        //StartCoroutine(LoadFromStart());
    }

    void LoadFromStart()
    {
        //yield return new WaitForSeconds(loadingScreenTimeInSeconds);
        SceneManager.LoadScene("Start Screen");
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }  
    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    } 
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }
    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }
    public void LoadLoseScreen()
    {
        SceneManager.LoadScene("Lose Screen");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
