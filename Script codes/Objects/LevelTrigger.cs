using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    // level transition variable
    [SerializeField]
    public string levelTransition;

    public Timer timer;

    private void OnCollisionStay(Collision collision)
    {
        // if player collides with the level trigger
        if (collision.gameObject.CompareTag("Player"))
        {
            LoadNextLevel();
        }

    }

    // load next level
    public void LoadNextLevel()
    {
        timer.TimeLeft();
        SceneManager.LoadScene(levelTransition);
    }



}
