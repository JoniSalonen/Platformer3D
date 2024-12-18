using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransitions : MonoBehaviour
{
    public string nextLevel;
    public string mainMenu;

    // Load the First level
    public void PlayGame()
    {
        SceneManager.LoadScene(nextLevel);
    }

    // Quit the game
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // Load the next level
    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);

    }

    // Load the main menu
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }


}
