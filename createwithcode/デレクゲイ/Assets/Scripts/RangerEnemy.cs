using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerEnemy : MonoBehaviour
{
    public float farthestAway = 50.0f;
    public float closestAway = 25.0f;
    public float speed = 1.0f;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        float h = player.transform.position.x - transform.position.x;
        float v = player.transform.position.z - transform.position.z;
        float angle = -Mathf.Atan2(v,h) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(180, angle, 0);
    }
}
