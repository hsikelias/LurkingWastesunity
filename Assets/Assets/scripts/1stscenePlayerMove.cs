using UnityEngine;

public class PlayerMovementController: MonoBehaviour
{
            public CharacterController controller;   // Reference to the CharacterController component
    public float speed = 6f;                 // Movement speed for walking
    public float runSpeed = 12f;             // Movement speed for running
    public float gravity = -9.81f;           // Gravity value
    public float jumpHeight = 1.0f;          // Jump height (if you want to add jumping later)

    private Vector3 velocity;                // Player's velocity for movement calculations
    public Transform groundCheck;            // To check if the player is grounded
    public float groundDistance = 0.4f;      // Ground detection radius
    public LayerMask groundMask;             // The layer representing the ground

    private bool isGrounded;                 // To store if the player is grounded
    private float currentSpeed;              // Stores the current speed (either walking or running)
    
    public Animator animator;                // Reference to the Animator component

    void Update()
    {
        // Ground check to reset velocity if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Ensure the player stays grounded by resetting the y velocity
        }

        // Get movement input from the player (WASD or arrow keys)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate the movement direction relative to the player's facing direction
        Vector3 move = transform.right * x + transform.forward * z;

        // Determine if the player is walking or running
        if (Input.GetKey(KeyCode.LeftShift) && move.magnitude > 0) // Hold Shift to run
        {
            currentSpeed = runSpeed;
            animator.SetBool("isRunning", true); // Trigger run animation
            animator.SetBool("isWalking", false);
        }
        else if (move.magnitude > 0) // Walking
        {
            currentSpeed = speed;
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", true); // Trigger walk animation
        }
        else // Idle
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false); // Trigger idle animation
        }

        // Move the player using the CharacterController
        controller.Move(move * currentSpeed * Time.deltaTime);

        // Apply gravity to the player
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}

