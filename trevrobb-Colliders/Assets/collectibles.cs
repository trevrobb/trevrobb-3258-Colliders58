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
    }

    // Update is called once per frame
    void Update()
    {
        if (range == 0)
        {
            transform.Translate(collectibleSpeed * Vector3.forward);
        }
        else if (range == 1)
        {
            transform.Translate(collectibleSpeed * Vector3.right);
        }
        else if (range == 2)
        {
            transform.Translate(collectibleSpeed * Vector3.left);
        }
        if (transform.position.x > 102f)
        {
            transform.position = new Vector3(-77f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -80f)
        {
            transform.position = new Vector3(102f, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -1f)
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
