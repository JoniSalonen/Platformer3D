using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseLocking : MonoBehaviour
{
   
    void Start()
    {
        // Get the current scene name
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        // Lock the mouse in the game scene
        if (sceneName == "FirstLevel" || sceneName == "SecondLevel")
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
