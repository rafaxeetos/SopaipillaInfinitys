 using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isJumping = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalImput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalImput * moveSpeed, rb.velocity.y, 0f);
        rb.velocity = movement;

        if (horizontalImput > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if (horizontalImput < 0)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Detectar si ha aterrizado en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Detectar si ha dejado de tocar el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
