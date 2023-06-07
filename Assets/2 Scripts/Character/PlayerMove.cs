using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;

    private bool isJumping;
    private bool isFacingRight = true;
    
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", false);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calcula la velocidad de movimiento en función del input horizontal
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed;

        // Aplica la velocidad de movimiento al Rigidbody
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Verifica si se ha presionado la barra espaciadora para saltar
            isJumping = true;
        }

        // Verifica si se ha presionado la tecla "A" para cambiar la dirección del modelo
        if (horizontalInput < 0f && isFacingRight)
        {
            FlipCharacter();
        }
        // Verifica si se ha presionado la tecla "D" para cambiar la dirección del modelo
        else if (horizontalInput > 0f && !isFacingRight)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        Vector3 scale = transform.localScale;

        // Invierte la escala en el eje Y
        scale.y *= -1f;

        // Aplica la nueva escala al jugador
        transform.localScale = scale;

        // Cambia el estado de isFacingRight
        isFacingRight = !isFacingRight;
    }

    private void FixedUpdate()
    {
        // Aplica la fuerza de salto al Rigidbody si se está saltando
        if (isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }
    }
}
