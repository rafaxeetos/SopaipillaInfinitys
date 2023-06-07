using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isJumping = false;
    private Vector3 initialScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialScale = transform.localScale;
    }

    private void Update()
    {
        float horizontalImput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalImput * moveSpeed, rb.velocity.y, 0f);
        rb.velocity = movement;

        if (horizontalImput > 0)
        {
            transform.localScale = initialScale;
        }
        else if (horizontalImput < 0)
        {
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
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
