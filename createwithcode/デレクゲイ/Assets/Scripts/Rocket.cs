using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private float speed = 10.0f;
    private float lifespan;

    private GameObject player;
    private PlayerController playerController;
    private Rigidbody selfRb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        selfRb = GetComponent<Rigidbody>();
        lifespan = Random.Range(5, 15);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        float h = player.transform.position.x - transform.position.x;
        float v = player.transform.position.z - transform.position.z;
        float angle = -Mathf.Atan2(v,h) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(180, angle - 90, 0);

        lifespan -= Time.deltaTime;
        if (lifespan < 0) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.name == "Player") {
            playerController.decreaseHealth(15);

            Destroy(gameObject);
        }
    }
}
