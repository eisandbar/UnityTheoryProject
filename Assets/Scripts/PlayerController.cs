using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 position { get; private set; }
    private float speed = 25;
    private float bound = 8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Move(Vector3.right, horizontalInput);
        Move(Vector3.forward, verticalInput);

        BoundMovement();

        position = transform.position;
    }

    private void Move(Vector3 direction, float input)
    {
        transform.Translate(direction * input * Time.deltaTime * speed);
    }

    private void BoundMovement()
    {
        float x = transform.position.x;
        float z = transform.position.z;
        if (transform.position.x > bound)
        {
            x = bound;
        }
        if (transform.position.x < -bound)
        {
            x = -bound;
        }
        if (transform.position.z > bound)
        {
            z = bound;
        }
        if (transform.position.z < -bound)
        {
            z = -bound;
        }
        transform.position = new Vector3(x, 0, z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Token"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        
    }
}
