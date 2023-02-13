using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInBounds : MonoBehaviour
{
    private float upperBound = 30.0f;
    private float horizontalBound = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position.x > horizontalBound) {
            transform.position = new Vector3(30, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -horizontalBound) {
            transform.position = new Vector3(-30, transform.position.y, transform.position.z);
        }
        if (transform.position.z > upperBound) {
            transform.position = new Vector3(transform.position.x, transform.position.y, 30);
        }
        else if (transform.position.z < -upperBound) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -30);
        }
    }
}
