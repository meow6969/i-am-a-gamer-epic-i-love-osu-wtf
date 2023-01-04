using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;
    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = -Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        if (transform.position.x > 30) {
            transform.position = new Vector3(30, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -30) {
            transform.position = new Vector3(-30, transform.position.y, transform.position.z);
        }
        if (transform.position.z > 30) {
            transform.position = new Vector3(transform.position.x, transform.position.y, 30);
        }
        else if (transform.position.z < -30) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -30);
        }
    }
}
