using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenuUI;


    void Start()
    {
        // Hide the pause menu
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        // Check if the escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           // Check if the game is paused
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }


    // Pause the game
    public void PauseGame()
    {
        
        isPaused = true;
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }

    // Resume the game
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
    }
}
