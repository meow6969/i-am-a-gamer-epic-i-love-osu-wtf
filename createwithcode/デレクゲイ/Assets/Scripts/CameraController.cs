using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private float speedX;
    private float speedZ;
    public float cameraLag = 7;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        speedX = (player.transform.position.x - transform.position.x)/cameraLag;
        speedZ = (player.transform.position.z - transform.position.z)/cameraLag;
        transform.Translate(new Vector3(speedX, speedZ, 0));
    }
}
