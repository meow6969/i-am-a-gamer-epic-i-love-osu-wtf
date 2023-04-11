using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public int speed = 20;
    public float explosionForce = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        if (transform.position.x > 50.0f || transform.position.x < -50.0f || transform.position.z > 50.0f || transform.position.z < -50.0f) {
            Destroy(gameObject);
        } 
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRigidbody.AddForce(awayFromPlayer * explosionForce, ForceMode.Impulse);

            Destroy(gameObject);
        }
    }
}
