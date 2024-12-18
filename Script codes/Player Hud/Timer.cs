using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameOverScreen GameOver;
    public float timeRemaining=150;
    public Text timerText;

    // Update is called once per frame
    void Update()
    {
        // if time is greater than 0, then time will be reduced by 1 second
        if (timeRemaining > 0)
        {
            GameOver.Playing();
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            // if time is less than 0, then time will be set to 0 and cursor will be unlocked
            timeRemaining = 0;
            Cursor.lockState = CursorLockMode.None;
            GameOver.Setup();
            
        }
        DisplayTime(timeRemaining);
    }

    // Displaying the time in minutes and seconds
    void DisplayTime(float timeToDisplay)
    {
        // if time is less than 0, then time will be set to 0
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        // if time is greater than 0, then time will be increased by 1 second to get proper time shown
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        // converting the time into minutes and seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // changing the color of the timer text to red if time is less than 30 seconds
        if(timeRemaining < 30)
        {
            timerText.color = Color.red;
        }
        else
        {
            timerText.color = Color.blue;
        }
        // displaying the time in minutes and seconds
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Adding time to the timer
    public void AddTime(float timeToAdd)
    {
        timeRemaining += timeToAdd;
    }

    // Removing time from the timer
    public void RemoveTime(float timeToRemove) 
    { 
        timeRemaining -= timeToRemove;
    }

    // Adding points to the total points
    public void TimeLeft()
    {
        float points = timeRemaining * 10;
        int pointsInt = (int)points;
        StaticData.levelPoints = pointsInt;
        StaticData.totalPoints = StaticData.totalPoints + pointsInt;
        Debug.Log(StaticData.totalPoints);
    }

}
