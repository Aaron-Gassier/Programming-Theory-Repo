using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 4.0f;
    private float xzRange = 10;
    private float horizontalInput;
    private float verticalInput;
    private int alive = 1;


    

    // Update is called once per frame
    void Update()
    {
        alive = FindObjectsOfType<Player>().Length;

        if(alive != 0)
        {
            CheckRange();
            Move();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
   
    private void Move()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
    }

    private void CheckRange()
    {
        if (transform.position.x < -xzRange)
        {
            transform.position = new Vector3(-xzRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xzRange)
        {
            transform.position = new Vector3(xzRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -xzRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -xzRange);
        }

        if (transform.position.z > xzRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, xzRange);
        }
    }
}
