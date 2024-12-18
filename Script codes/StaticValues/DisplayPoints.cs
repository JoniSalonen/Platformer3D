using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPoints : MonoBehaviour
{
    [SerializeField] Text points;

    public void Start()
    {
        // Display the total points of the player
        string point = StaticData.totalPoints.ToString();
        string pointsText = "Your Points: " + point;
        points.text = pointsText;
    }
}
