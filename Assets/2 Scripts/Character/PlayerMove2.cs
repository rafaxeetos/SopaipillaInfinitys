using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    public bool isGrounded = true;

    void Start()
    {

    }

    void Update()
    {
        float horizontalImput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0f, 0f, horizontalImput) * speed * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("isGrounded: " + isGrounded);
            if (isGrounded)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            return;
        }
    }
}
