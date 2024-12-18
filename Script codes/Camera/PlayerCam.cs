using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    //Sensitivity
    public float sensX;
    public float sensY;

    //Transforms
    public Transform orientation;
    
    //Rotation and look
    float yRotation;
    float xRotation;

    private void start()
    { 
        //Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        //Hide cursor
        Cursor.visible = true;
    }

    private void Update()
    {
        //Get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        //Calculate rotation
        yRotation += mouseX;
        
        //Calculate rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Apply rotation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
