using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Set variables for the platform's two positions and speed
    [SerializeField]
    private Transform position1, position2;
    [SerializeField]
    private float _speed;
    private bool _switch = false;
    private Vector3 lastPlatformPosition;
    private Vector3 platformMovement;

    private void Start()
    {
        // Set the platform's starting position
        lastPlatformPosition = transform.position;
    }

    // Move the platform between the two positions
    void FixedUpdate()
    {
        if (_switch == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, position1.position,
                _speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, position2.position,
                _speed * Time.deltaTime);
        }

        // Switch the platform's direction when it reaches one of the positions
        if (transform.position == position1.position)
        {
            _switch = true;
        }
        else if (transform.position == position2.position)
        {
            _switch = false;
        }

        // Calculate platform movement since last frame
        platformMovement = transform.position - lastPlatformPosition;
        lastPlatformPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player or box is on the platform, move them along with the platform
        if (other.CompareTag("Player"))
        {
            // Move the player along with the platform
            other.transform.parent = transform;
        }

        if (other.CompareTag("Box"))
        {
            // Move the box along with the platform
            other.transform.parent = transform;
        }
    }

    // Stop moving the player or box with the platform
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop moving the player with the platform
            other.transform.parent = null;
        }

        if (other.CompareTag("Box"))
        {
            // Stop moving the pbox with the platform
            other.transform.parent = null;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // If a player is on the platform, move the player along with the platform's movement
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position += platformMovement;
        }

        // If a box is on the platform, move the box along with the platform's movement
        if (collision.gameObject.CompareTag("Box"))
        {
            collision.transform.position += platformMovement;
        }
    }
}