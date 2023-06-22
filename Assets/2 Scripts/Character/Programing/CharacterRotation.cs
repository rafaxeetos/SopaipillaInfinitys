using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public Transform playerTransform;

    private float pitch = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotar la vista del personaje en el eje horizontal (Yaw)
        playerTransform.Rotate(0f, mouseX, 0f);

        // Rotar la vista de la cámara en el eje vertical (Pitch)
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}
