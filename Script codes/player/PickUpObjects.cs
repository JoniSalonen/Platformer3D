using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    // Set Variables
    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private Transform objectGrabPointTransform;

    [SerializeField]
    private LayerMask pickUpLayerMask;

    [SerializeField]
    private float pickUpDistance = 2f;

    private GrabbableObject currentGrabbedObject;

    void Update()
    {
        // Check if the player is pressing the E key
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if the player is already holding an object
            if (currentGrabbedObject != null)
            {
                currentGrabbedObject.Release();
                currentGrabbedObject = null;
                return;
            }

            // Check if the player is looking at an object
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
            {
                // Check if the object is a GrabbableObject
                if (raycastHit.transform.TryGetComponent(out GrabbableObject grabbableObject))
                {
                    // Grab the object
                    grabbableObject.Grab(objectGrabPointTransform); // Pass objectGrabPointTransform here
                    currentGrabbedObject = grabbableObject;
                }
            }
        }
    }
}
