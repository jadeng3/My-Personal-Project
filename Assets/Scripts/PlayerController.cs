using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f; // The force applied to make the player jump
    private Rigidbody playerRb;
    public float xRange = 10.0f;
    public float gravityModifier;

    public float jumpforce = 10.0f;
    public int maxJumps = 50; // The maximum number of jumps the player can perform
    private int jumpCount = 0; // The number of jumps the player has performed


    private Rigidbody rb; // The Rigidbody component of the player

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            Jump();
        }
        if (transform.position.x < -xRange)
        { transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); }
        if (transform.position.x < xRange)
        { transform.position = new Vector3(xRange, transform.position.y, transform.position.z); }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        jumpCount++;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
}

