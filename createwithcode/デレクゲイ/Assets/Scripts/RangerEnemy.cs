using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerEnemy : MonoBehaviour
{
    private float farthestAway = 20.0f;
    public float closest = 10.0f;
    private float speed = 5.0f;
    private float rocketTimer = 0f;

    private GameObject player;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    private Rigidbody selfRb;

    private Object rocket;
    private GameObject spawnedRocket;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        selfRb = GetComponent<Rigidbody>();
        rocket = Resources.Load("Rocket");
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManagerScript.gameActive) {
            return;
        }

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > farthestAway) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        } else if (distance < closest) {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        float h = player.transform.position.x - transform.position.x;
        float v = player.transform.position.z - transform.position.z;
        float angle = -Mathf.Atan2(v,h) * Mathf.Rad2Deg;

        var rotation = Quaternion.Euler(0, angle, 0);

        transform.rotation = rotation;

        if (spawnedRocket == null) {
            rocketTimer += Time.deltaTime;
            if (rocketTimer > 3f) {
                spawnedRocket = Instantiate(rocket, transform.position, rotation) as GameObject;
                // spawnedRocket = t.gameObject;
                spawnedRocket.GetComponent<RocketScript>().allegiance = false;
                rocketTimer = 0f;
            } 
        }
    }
}
