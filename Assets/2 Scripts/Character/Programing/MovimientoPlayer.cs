 using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float gravity = 20f;
    
    private CharacterController controller;
    private bool isJumping = false;
    private Vector3 velocity;
    public GameObject faceStart;
    public GameObject otherFace;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        otherFace.SetActive(false);
        faceStart.SetActive(true);
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput * moveSpeed, 0f, 0f);
        controller.Move(movement * Time.deltaTime);

        if (horizontalInput > 0)
        {
            faceStart.SetActive(true);
            otherFace.SetActive(false);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (horizontalInput < 0)
        {
            faceStart.SetActive(false);
            otherFace.SetActive(true);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            velocity.y = Mathf.Sqrt(jumpForce * 2f * gravity);
            controller.Move(Vector3.up * jumpForce * Time.deltaTime);
            isJumping = true;
        }
        
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded)
        {
            velocity.y = -gravity * Time.deltaTime;
            isJumping = false;
        }
    }
}
