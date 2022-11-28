using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IAmAddictedToHeroin", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IAmAddictedToHeroin() { // please take me out of school so then i can inject more heroin into my body i hate everything please i want this to end
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
