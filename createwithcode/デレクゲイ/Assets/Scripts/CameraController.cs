using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float cameraLag = 7;
    public float paralaxOffset = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        float speedX = (player.transform.position.x - transform.position.x) / cameraLag;
        float speedZ = (player.transform.position.z - transform.position.z) / cameraLag;

        transform.Translate(new Vector3(speedX, speedZ, 0));
    }
}
