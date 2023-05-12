using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RusherEnemy : MonoBehaviour
{
    private float speed = 14.0f;
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
        if (moving) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        float h = player.transform.position.x - transform.position.x;
        float v = player.transform.position.z - transform.position.z;
        float angle = -Mathf.Atan2(v,h) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(180, angle, 0);
    }

    void OnCollisionEnter(Collision collision) {
        // Debug.Log(collision.collider.name);
        if (collision.collider.name == "Player") {
            playerController.decreaseHealth(25);
            // Debug.Log(collision.collider.name);
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
