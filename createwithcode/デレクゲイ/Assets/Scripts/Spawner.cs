using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    private float spawnTimer = 0f;
    private int timeToWait;

    private GameObject player;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        timeToWait = Random.Range(1, 10);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > timeToWait && gameManager.spawnsEnabled) {
            float h = player.transform.position.x - transform.position.x;
            float v = player.transform.position.z - transform.position.z;
            float angle = -Mathf.Atan2(v,h) * Mathf.Rad2Deg;

            var rotation = Quaternion.Euler(180, angle, 0);
            Instantiate(enemies[Random.Range (0, enemies.Length)], new Vector3(transform.position.x + Random.Range(-5f, 5f), 1, transform.position.z + Random.Range(-5f, 5f)), rotation);
            spawnTimer = 0f;
            timeToWait = Random.Range(1, 10);
        } else if (!gameManager.spawnsEnabled) {
            spawnTimer = 0f;
        }
    }
}
