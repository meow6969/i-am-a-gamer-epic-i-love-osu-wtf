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
    private float powerupStrength = 15.0f;
    private Rigidbody enemyRigidbody;
    private Vector3 awayFromPlayer;
    public GameObject powerupIndicator;
    public int rocketNum = 16;
    public GameObject rocket;

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
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Powerup")) {
            powerupIndicator.gameObject.SetActive(true);
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        } else if (other.CompareTag("Powerup2")) {
            for (int i = 0; i < rocketNum; i++){
                Vector3 pos = RandomCircle(transform.position, 2.0f);
                Quaternion rot = Quaternion.FromToRotation(Vector3.forward, transform.position-pos);
                Instantiate(rocket, pos, rot);
            }
            Destroy(other.gameObject);
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

    Vector3 RandomCircle(Vector3 center, float radius){
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
     }
}
