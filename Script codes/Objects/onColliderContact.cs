using UnityEngine;

public class ObjectPushing : MonoBehaviour
{
    // set the force magnitude
    [SerializeField] 
    private float forceMagnitude = 1;

    // when the player collides with the object, the object will be pushed away from the player
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // get the rigidbody of the object
        Rigidbody _rigidBody = hit.collider.attachedRigidbody;

        if (_rigidBody != null)
        {
            // get the direction of the force
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            _rigidBody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);

        }
        
    }
}
