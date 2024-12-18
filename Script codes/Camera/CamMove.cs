using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform cameraPosition;

    // Update is called once per frame
    private void Update()
    {
        // Camera follows the player
        // Camera position is set to the player's position
        transform.position = cameraPosition.position;
    }
}
