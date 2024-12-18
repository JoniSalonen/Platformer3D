using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public Timer timer;
    public int timeToAdd = 100;

   private void OnTriggerEnter(Collider other)
    {
        //if the player collides with the collectable object, the player will gain time and the collectable object will be destroyed
        if (other.CompareTag("Player"))
        {
            //add time to the timer
            timer.AddTime(timeToAdd);
            //destroy the collectable object
            Destroy(gameObject);
        }
    }
}
