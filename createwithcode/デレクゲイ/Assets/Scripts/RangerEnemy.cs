using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerEnemy : MonoBehaviour
{
    private float farthestAway = 5.0f;
    public float closestAway = 25.0f;
    private float speed = 7.0f;

    private GameObject player;
    private Rigidbody selfRb;

    private Object rocket;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        selfRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > farthestAway) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        float h = player.transform.position.x - transform.position.x;
        float v = player.transform.position.z - transform.position.z;
        float angle = -Mathf.Atan2(v,h) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(180, angle, 0);
    }
}
