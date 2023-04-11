using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5.0f;
    private float forwardInput;
    private GameObject focalPoint;
    public bool hasPowerup;
    public bool hasPowerup2;
    private float powerupStrength = 15.0f;
    private Rigidbody enemyRigidbody;
    private Vector3 awayFromPlayer;
    public GameObject powerupIndicator;
    private int rocketNum = 32;
    public GameObject rocket;
    private float powerup2Countdown = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if (transform.position.y < -10) {
            transform.position = new Vector3(0, 0, 0);
            playerRb.velocity = new Vector3(0, 0, 0);
        }
        powerup2Countdown -= Time.deltaTime;
        if (powerup2Countdown < 0f) {
            hasPowerup2 = false;
            if (!hasPowerup) {
                powerupIndicator.gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown("space") && hasPowerup2 && transform.position.y < 0.5f && transform.position.y > 0f) {
            playerRb.AddForce(new Vector3 (0, 1, 0) * 20, ForceMode.Impulse);
            StartCoroutine(JumpCountdownRoutine());
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Powerup")) {
            powerupIndicator.gameObject.SetActive(true);
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        } else if (other.CompareTag("Powerup2")) {
            for (int i = 0; i < rocketNum; i++) {
                // Debug.Log(i);
                var pos = RandomCircle(transform.position, 0.0f, ((float)i / (float)rocketNum) * 360f);
                Quaternion rot = Quaternion.Euler(0, pos.Item2, 0);
                Instantiate(rocket, pos.Item1, rot);
            }
            Destroy(other.gameObject);
        } else if (other.CompareTag("Powerup3")) {
            powerupIndicator.gameObject.SetActive(true);
            hasPowerup2 = true;
            Destroy(other.gameObject);
            powerup2Countdown = 15f;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup) {
            enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine() {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    IEnumerator JumpCountdownRoutine() {
        yield return new WaitForSeconds(0.3f);
        playerRb.AddForce(new Vector3 (0, -1, 0) * 40, ForceMode.Impulse);
        yield return new WaitForSeconds(0.3f);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            distance = 20 - distance;
            if (distance < 0f) {
                distance = 0f;
            }
            awayFromPlayer = (enemy.transform.position - transform.position);
            enemyRigidbody = enemy.GetComponent<Rigidbody>();
            Debug.Log(distance);
            enemyRigidbody.AddForce(awayFromPlayer * (distance / 2), ForceMode.Impulse);
        }
    }
    
    (Vector3, float) RandomCircle(Vector3 center, float radius, float ang) {
        // float ang = Random.value * 360;
        // Debug.Log(ang);
        // Debug.Log(Random.value);
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.y = 1.0f;
        return (pos, ang);
     }
}
