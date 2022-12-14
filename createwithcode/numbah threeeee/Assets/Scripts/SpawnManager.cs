using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject scoreCounterPrefab;
    private Vector3 spawnPos = new Vector3(30, 0, 0);
    private float startDelay = 2;
    private float spawnInterval;
    private int obstacleIndex;
    private int doubleHeightObstacle;
    private PlayerController playerControllerScript;
    public float defaultMaxSpawnTime = 5.0f;
    public float maxSpawnTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("IAmAddictedToHeroin", startDelay);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey ("left shift")) {
            maxSpawnTime = defaultMaxSpawnTime / 2; 
        }
        else {
            maxSpawnTime = defaultMaxSpawnTime;
        }
    }

    void IAmAddictedToHeroin() { // please take me out of school so then i can inject more heroin into my body i hate everything please i want this to end
        if (!playerControllerScript.gameOver && playerControllerScript.gameReady) {
            obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            doubleHeightObstacle = Random.Range(0, 5);
            if (doubleHeightObstacle == 0) {
                Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
                Instantiate(scoreCounterPrefab, spawnPos, scoreCounterPrefab.transform.rotation);
            } else {
                Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
                Instantiate(obstaclePrefabs[obstacleIndex], spawnPos + new Vector3((-obstaclePrefabs[obstacleIndex].GetComponent<BoxCollider>().size.x)/5, obstaclePrefabs[obstacleIndex].GetComponent<BoxCollider>().size.y, 0), obstaclePrefabs[obstacleIndex].transform.rotation);
                Instantiate(scoreCounterPrefab, spawnPos, scoreCounterPrefab.transform.rotation);
            }
        }
        spawnInterval = Random.Range(1, maxSpawnTime);
        Invoke("IAmAddictedToHeroin", spawnInterval);
    }
}
