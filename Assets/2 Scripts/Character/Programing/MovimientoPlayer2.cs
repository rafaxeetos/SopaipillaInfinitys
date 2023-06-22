using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float gravity = 20f;
    public GameObject boton2;
    public GameObject boton4;
    public GameObject pared2;
    public GameObject pared3;
    public GameObject piso1;
    public GameObject piso2;
    public GameObject pauseMenu;

    private CharacterController controller;
    private bool isJumping = false;
    private Vector3 velocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        piso1.SetActive(true);
        piso2.SetActive(false);
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Vertical");
        float verticalInput = Input.GetAxis("Horizontal1");

        Vector3 movement = new Vector3(horizontalInput * moveSpeed, 0f, verticalInput * moveSpeed);
        controller.Move(movement * Time.deltaTime);
        
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.Abs(transform.localScale.z));
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -Mathf.Abs(transform.localScale.z));
        }

        if (controller.isGrounded)
        {
            velocity.y = -gravity * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = Mathf.Sqrt(jumpForce * 2f * gravity);
                isJumping = true;
            }
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boton2"))
        {
            Destroy(boton2);
            Destroy(pared2);
            Destroy(pared3);
        }

        if (other.CompareTag("Boton4"))
        {
            Destroy(boton4);
            Destroy(piso1);
            piso2.SetActive(true);
        }
    }
}
