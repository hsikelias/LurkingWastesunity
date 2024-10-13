using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    private float speed;
    
    private Vector3 moveDirection;
    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();  // Reference to Animator component
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Get input for movement
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        // Calculate movement direction
        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection.Normalize();

        // Determine whether to walk or run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;  // Running 
        }
        else
        {
            speed = walkSpeed;  // Walking
        }

        // Move the player
        controller.Move(moveDirection * speed * Time.deltaTime);

        // Update the Speed parameter in the Animator
        animator.SetFloat("Speed", moveDirection.magnitude * speed);
    }
}
