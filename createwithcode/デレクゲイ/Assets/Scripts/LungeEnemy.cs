using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungeEnemy : MonoBehaviour
{
    private float speedOffset = 90.0f;
    private float speedDecline = 1.15f;
    public float speed = 0.0f;
    [SerializeField] bool moving = true;

    private GameObject player;
    private PlayerController playerController;
    private Rigidbody selfRb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        selfRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (speed < 0.1f) {
            if (moving) {
                speed = speedOffset;
                float h = player.transform.position.x - transform.position.x;
                float v = player.transform.position.z - transform.position.z;
                float angle = -Mathf.Atan2(v,h) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Euler(0, angle, 0);
            }
        } else {
            speed /= speedDecline;
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision) {
        // Debug.Log(collision.collider.name);
        if (collision.collider.name == "Player") {
            // Debug.Log(collision.collider.name);
            playerController.decreaseHealth(25);

            moving = false;
        }
    }

    void OnCollisionExit(Collision other) {
        if (other.collider.name == "Player") {
            // Debug.Log(collision.collider.name);
            moving = true;
        }
    }
}
