using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 50.0f;
    private Rigidbody playerRb;

    public float xRange = 10.0f;
    public float zRange = 1.0f;
    public float jumpForce = 10.0f;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameOver = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(-zRange, transform.position.y, transform.position.x);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(zRange, transform.position.y, transform.position.x);
        }


        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with enemy");
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }
}
