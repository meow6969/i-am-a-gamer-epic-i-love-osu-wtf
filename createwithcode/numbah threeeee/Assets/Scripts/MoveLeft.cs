using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float defaultSpeed = 15.0f;
    private float speed = 15.0f;
    private PlayerController playerControllerScript; 
    private float downBound = -1;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver && playerControllerScript.gameReady) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.y < downBound) {
            Destroy(gameObject);
        }
        if(Input.GetKey ("left shift")) {
            speed = defaultSpeed * 2; 
        }
        else {
            speed = defaultSpeed;
        }
        
    }
}
