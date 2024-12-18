using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    [Header("Movement")]
    public float movementSpeed;
    public float sprintSpeed;

    public float groundDrag;

    public float jumpForce;
    public float airMultiplier;
    public float sprintCD;
    public float sprintDuration;

    public int maxJumps = 2;
    private int jumpsRemaining;

    // Keybinds
    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    // Ground Check
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask ground;
    public LayerMask platform;

    // Private Variables
    bool grounded;
    bool onPlatform;
    bool sprintReady;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    float currentSpeed;

    Vector3 moveDirection;

    // Components
    Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        jumpsRemaining = maxJumps;

        sprintReady = true;
    }

    // Update is called once per frame
    private void Update()
    {
        // Ground Check
        grounded = Physics.Raycast(transform.position, Vector3.down * 0.5f, +0.2f, ground);
        // Platform Check
        onPlatform = Physics.Raycast(transform.position, Vector3.down * 0.5f, +0.2f, platform);

        MyInput();
        SpeedControl();

        // Drag
        if (grounded || onPlatform)
        {
            rb.drag = groundDrag;
            jumpsRemaining = maxJumps; // Reset jumps when grounded
        }
        else
            rb.drag = 0;

        // Sprint Cooldown
        if (sprintReady == false) 
        {
                SprintCooldown();
        }
    }
    
    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Custom Functions
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when jumping
        if (Input.GetKeyDown(jumpKey) && jumpsRemaining > 0)
        {
            if (!grounded || !onPlatform)
            {
                jumpsRemaining--; // Decrease jumps when in the air
            }

            Jump();
        }

        // when sprinting
        if (Input.GetKey(sprintKey) && sprintReady == true)
        {
            currentSpeed = sprintSpeed;
            sprintDuration -= Time.deltaTime;
            if (sprintDuration < 0) {
                currentSpeed = movementSpeed;
                sprintReady = false;
                sprintCD = 5f;
            }
            
        }
        else
        {
            currentSpeed = movementSpeed;

            if (sprintDuration > 0 && sprintDuration < 5)
            {
                sprintDuration += Time.deltaTime;

                if (sprintDuration > 5)
                {
                    sprintDuration = 5f;
                }
            }
        }
    }

    // Move the player
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded || onPlatform)
            rb.AddForce(moveDirection.normalized * currentSpeed * 10f, ForceMode.Force);

        else if (!grounded || !onPlatform)
            rb.AddForce(moveDirection.normalized * currentSpeed * airMultiplier * 10f, ForceMode.Force); 
    }

    // Limit the speed of the player
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > currentSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * currentSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    // Jump
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); 

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    // Sprint Cooldown
    private void SprintCooldown()
    {
        sprintCD -= Time.deltaTime;

        if (sprintCD < 0)
        {
            sprintReady = true;
            sprintCD = 0f;
            sprintDuration = 5f;
        }
    }
}
