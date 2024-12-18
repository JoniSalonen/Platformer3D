using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public void Setup()
    {
        // Set the game object to active
        gameObject.SetActive(true);
    }

    public void Playing()
    {
        // Set the game object to inactive
        gameObject.SetActive(false);
    }
}
