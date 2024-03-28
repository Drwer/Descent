using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 100f; // Mouse sensitivity
    public Transform playerBody; // Reference to the player's body to rotate along with the camera

    float xRotation = 0f;

    void Start()
    {
        // Lock cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Capture mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Rotate the camera vertically
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit vertical rotation to prevent flipping

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player horizontally
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
