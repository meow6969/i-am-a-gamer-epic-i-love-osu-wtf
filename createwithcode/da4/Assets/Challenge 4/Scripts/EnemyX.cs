using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speedOffset = 50.0f;
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    private GameObject spawnManager;
    private SpawnManagerX spawnManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");
        spawnManager = GameObject.Find("Spawn Manager");
        spawnManagerScript = spawnManager.GetComponent<SpawnManagerX>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = spawnManagerScript.waveCount * speedOffset;
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
