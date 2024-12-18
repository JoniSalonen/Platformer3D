using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    // get the waypoint index
    public Transform GetWaypoint(int waypointIndex)
    {
        return transform.GetChild(waypointIndex);
    }

    // get the next waypoint index
    public int GetNextWaypointIndex(int currentWaypointIndex)
    {
        int nextWaypointIndex = currentWaypointIndex + 1;

        // if the next waypoint index is greater than the number of waypoints, reset the index to 0
        if (nextWaypointIndex == transform.childCount)
        {
            // reset the index to 0
            nextWaypointIndex = 0;
        }

        // return the next waypoint index
        return nextWaypointIndex;
    }
}