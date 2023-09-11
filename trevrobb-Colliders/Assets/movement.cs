using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody rb;
    [SerializeField] float jumpForce;
    private Vector3 spawnPos;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.AddForce(movement * speed);
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {     
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);   
        }

        if (transform.position.y < -1f)
        {
            transform.position = spawnPos;
        }
    }
    
}
