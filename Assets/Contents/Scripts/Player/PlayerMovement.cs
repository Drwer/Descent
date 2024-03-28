using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody rb;
    Vector3 movementDirection = Vector3.zero;
    public LayerMask groundMask;
    public LayerMask wallMask;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movementDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movementDirection += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementDirection -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementDirection -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementDirection += transform.right;
        }
    }

    void FixedUpdate()
    {
        // Move the player
        rb.velocity = movementDirection.normalized * moveSpeed;

        // Check for collisions with ground
        if (Physics.Raycast(transform.position, Vector3.down, 0.1f, groundMask))
        {
            // If player is colliding with ground, stop downward velocity
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        }

        // Check for collisions with walls
        RaycastHit hit;
        if (Physics.Raycast(transform.position, rb.velocity.normalized, out hit, rb.velocity.magnitude * Time.fixedDeltaTime, wallMask))
        {
            // If player is about to collide with a wall, stop movement
            rb.velocity = Vector3.zero;
        }
    }
}
