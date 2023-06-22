 using System;
 using System.Collections;
using System.Collections.Generic;
 using UnityEditor.Animations;
 using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float jumpTrampo = 10f;
    public float gravity = 20f;
    public GameObject boton1;
    public GameObject boton3;
    public GameObject boton5;
    public GameObject pared1;
    public GameObject pared4;
    public GameObject pauseMenu;


    private CharacterController controller;
    private bool isJumping = false;
    private Vector3 velocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput * moveSpeed, 0f, 0f);
        controller.Move(movement * Time.deltaTime);

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.Abs(transform.localScale.z));
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -Mathf.Abs(transform.localScale.z));
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

        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpTrampo * 2f * gravity);
        controller.Move(Vector3.up * jumpTrampo * Time.deltaTime);
        isJumping = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Trampolin"))
        {
            Jump();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boton1"))
        {
            Destroy(boton1);
            Destroy(pared1);
        }

        if (other.CompareTag("Boton3"))
        {
            Destroy(pared4);
            Destroy(boton3);
        }

        if (other.CompareTag("Boton5"))
        {
            Destroy(boton5);
        }
    }
}
