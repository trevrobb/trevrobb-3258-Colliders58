using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class collectibles : MonoBehaviour
{
    [SerializeField] float collectibleSpeed;
    private int range;
    private Vector3 spawnPos;
    void Start()
    {
        range = (int)Random.Range(0, 3);
        Debug.Log(range);
        spawnPos = this.transform.position;
        collectibleSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (range == 0)
        {
            transform.Translate(collectibleSpeed * Vector3.forward);
            this.GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (range == 1)
        {
            transform.Translate(collectibleSpeed * Vector3.right);
            this.GetComponent<Renderer>().material.color = Color.black;
        }
        else if (range == 2)
        {
            transform.Translate(collectibleSpeed * Vector3.left);
            this.GetComponent<Renderer>().material.color = Color.green;
        }
        if (transform.position.x > 120f)
        {
            transform.position = new Vector3(-77f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -120f)
        {
            transform.position = new Vector3(102f, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -1f)
        {
            transform.position = spawnPos;
        }
        if (transform.position.z > 2800f)
        {
            transform.position = spawnPos;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
