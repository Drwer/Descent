using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + transform.TransformDirection(movement));
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            RotateX(-rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            RotateX(rotationSpeed * Time.deltaTime);
        }
    }

    void RotateX(float angle)
    {
        Quaternion deltaRotation = Quaternion.Euler(0f, angle, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}