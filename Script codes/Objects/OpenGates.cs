using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGates : MonoBehaviour
{

    [SerializeField]
    private bool KeyToOpen = false;

    [SerializeField]
    private Transform trigger; 

    [SerializeField]
    private GameObject[] closedGates;
    [SerializeField]
    private GameObject[] openGates; 


    // upating the state of the gates
    void Update()
    {
        if (KeyToOpen == true)
        {
            ToggleObjectsState(closedGates);
            ToggleObjectsState(openGates);
            KeyToOpen = false;
        }
    }

    // toggling the state of the objects
    void ToggleObjectsState(GameObject[] objects)
    {
        // loop through the objects
        foreach (GameObject obj in objects)
        {
            // get the collider component
            Collider collider = obj.GetComponent<Collider>();
            if (collider != null)
                collider.enabled = !collider.enabled;
            else if(collider == null)
            {
                collider.enabled = !collider.enabled;
            }

            // get the renderer component
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
                renderer.enabled = !renderer.enabled;
            else if(renderer == null)
            {
                renderer.enabled = !renderer.enabled;
            }

        }   

           
    }

    // if the key hits the trigger
    void OnCollisionStay(Collision other)
    {
        // if the key hits the trigger
        if (other.gameObject.CompareTag("Key"))
        {
            // set the key to open the gates
            KeyToOpen = true;

            // destroy the key
            Destroy(other.gameObject);

            // get the collider component
            Collider collider = trigger.GetComponent<Collider>();
            
            // toggle the state of the trigger
            collider.enabled = !collider.enabled;

        }
    }
}
