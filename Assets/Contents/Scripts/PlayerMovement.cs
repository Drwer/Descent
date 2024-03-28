using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody rb;
    Vector3 movementDirection = Vector3.zero;

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
        rb.velocity = movementDirection.normalized * moveSpeed;
    }
}
