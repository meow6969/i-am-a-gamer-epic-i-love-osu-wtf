using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float spawnInterval;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("IAmAddictedToHeroin", startDelay);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        // Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }

    void IAmAddictedToHeroin() { // please take me out of school so then i can inject more heroin into my body i hate everything please i want this to end
        if (!playerControllerScript.gameOver) {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        spawnInterval = Random.Range(1, 5);
        Invoke("IAmAddictedToHeroin", spawnInterval);
    }
}
