using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungeEnemy : MonoBehaviour
{
    public float speedOffset = 10.0f;
    public float speedDecline = 1.0f;
    private float speed = 0.0f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speed < 0.0f) {
            speed = speedOffset;
        } else {
            speed -= speedDecline;
        }

        float h = player.transform.position.x - transform.position.x;
        float v = player.transform.position.z - transform.position.z;
        float angle = -Mathf.Atan2(v,h) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(180, angle, 0);

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
