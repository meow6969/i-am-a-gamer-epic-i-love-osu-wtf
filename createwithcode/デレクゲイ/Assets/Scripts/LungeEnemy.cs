using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungeEnemy : MonoBehaviour
{
    private float speedOffset = 90.0f;
    private float speedDecline = 1.15f;
    public float speed = 0.0f;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (speed < 0.1f) {
            speed = speedOffset;
            float h = player.transform.position.x - transform.position.x;
            float v = player.transform.position.z - transform.position.z;
            float angle = -Mathf.Atan2(v,h) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(180, angle, 0);
        } else {
            speed /= speedDecline;
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
