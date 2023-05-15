using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnEnemy() {
        float h = player.transform.position.x - transform.position.x;
        float v = player.transform.position.z - transform.position.z;
        float angle = -Mathf.Atan2(v,h) * Mathf.Rad2Deg;

        var rotation = Quaternion.Euler(180, angle, 0);
        Instantiate(enemies[Random.Range (0, enemies.Length)], new Vector3(transform.position.x + Random.Range(-5f, 5f), 1, transform.position.z + Random.Range(-5f, 5f)), rotation);
    }
}
