using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    private float speed = 10.0f;
    private float lifespan;
    public bool allegiance;

    private GameObject player;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    private PlayerController playerController;
    private Rigidbody selfRb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        playerController = player.GetComponent<PlayerController>();
        selfRb = GetComponent<Rigidbody>();
        lifespan = Random.Range(5, 15);

        if (allegiance) {
            // float h = player.transform.position.x - transform.position.x;
            // float v = player.transform.position.z - transform.position.z;
            // float angle = -Mathf.Atan2(v,h) * Mathf.Rad2Deg;

            // transform.rotation = Quaternion.Euler(180, angle - 90, 0);

            speed = 30.0f;
            lifespan = 20.0f;
            // selfRb.isKinematic = false;
        } else {
            gameObject.tag = "Enemy";
            // selfRb.isKinematic = false;
        }
        // Debug.Log(allegiance);
    }

    // Update is called once per frame
    void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan < 0) {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (!allegiance) {
            float h = player.transform.position.x - transform.position.x;
            float v = player.transform.position.z - transform.position.z;
            float angle = -Mathf.Atan2(v,h) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(180, angle - 90, 0);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (allegiance && collision.collider.tag == "Enemy") {
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
            if (!collision.gameObject.name.Contains("Rocket")) {
                gameManagerScript.enemies --;
            }
        } else if (!allegiance && collision.collider.name == "Player") { 
            playerController.decreaseHealth(15);

            Destroy(gameObject);
        }
    }
}
