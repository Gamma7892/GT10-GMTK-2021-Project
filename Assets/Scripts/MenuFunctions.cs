using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuFunctions : MonoBehaviour
{
    public bool pausable = true;
    
    public GameObject backgroundPanel;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject quitConfirmationMenu;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Game ended via QuitGame()");
        Application.Quit();
    }

    public void TogglePause()
    {
        if(pausable)
        {
            PauseHandling.isPaused = !(PauseHandling.isPaused);

            backgroundPanel.SetActive(PauseHandling.isPaused);
            pauseMenu.SetActive(PauseHandling.isPaused);
            //handling edge case where player presses esc while a different menu is open.
            if (!PauseHandling.isPaused)
            {
                optionsMenu.SetActive(false);
                quitConfirmationMenu.SetActive(false);
            }
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    
}
