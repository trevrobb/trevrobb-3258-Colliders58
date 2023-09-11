using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody rb;
    [SerializeField] float jumpForce;
    private Vector3 spawnPos;

    private bool notJumping;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnPos = transform.position;
        notJumping = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.AddForce(movement * speed);
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && notJumping)
        {     
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            notJumping = false;
        }

        if (transform.position.y <= 2.5f)
        {
            notJumping = true;
        }

        if (transform.position.y < -1f)
        {
            transform.position = spawnPos;
        }
    }
    
}
