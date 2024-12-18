using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    private Rigidbody item;
    private Transform grabItemRange;   
    private bool isGrabbed = false;


    private void Awake()
    {
        item = GetComponent<Rigidbody>();
    }

    // grabs the object from the grabItemRange
    public void Grab(Transform grabItemRange)
    {
        // if the object is a key, it will not use gravity and will be kinematic
        this.grabItemRange = grabItemRange;

        if (CompareTag("Key"))
        {
            item.useGravity = false;
            isGrabbed = true;
            item.isKinematic = false;
        }
        else
        {
            // if the object is not a key, it will not use gravity and will be kinematic
            item.useGravity = false;
            isGrabbed = true;
            item.isKinematic = true;
        }
    }

    // releases the object from the grabItemRange
    public void Release()
    {
        item.useGravity = false;
        item.isKinematic = true;
        isGrabbed = false;
    }

    // moves the object to the grabItemRange
    private void FixedUpdate()
    {
        // if the object is grabbed and the grabItemRange is not null, the object will move to the grabItemRange
        if (isGrabbed && grabItemRange != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, grabItemRange.position, Time.deltaTime * lerpSpeed);
            item.MovePosition(newPosition);
        }
    }

}
