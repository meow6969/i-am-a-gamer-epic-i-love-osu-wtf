using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;
    private float horizontalInput;
    private float verticalInput;
    public TextMeshProUGUI healthText;
    // public GameObject camera;
    public float angle = 0.0f;
    private Vector3 mousePos;
    private float screenCenterX;
    private float screenCenterY;
    private float widthLength;
    private float heightLength;
    private float hypotenuseLength;
    public int health = 100;
    private float rocketTimer;
    private float invulnerabilityTimer = 0;
    private MeshRenderer selfMesh;
    private int frameSkip = 5;
    private int curSkip = 0;
    public Material red;
    public Material blue;
    private bool isBlue = true;

    private Object rocket;
    private GameObject spawnedRocket;

    // Start is called before the first frame update
    void Start()
    {
        screenCenterX = Screen.width / 2;
        screenCenterY = Screen.height / 2;
        rocket = Resources.Load("Rocket");
        selfMesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invulnerabilityTimer > 0f) {
            invulnerabilityTimer -= Time.deltaTime;
            curSkip -= 1;
            if (curSkip < 0) {
                // selfMesh.enabled = !selfMesh.enabled;
                if (isBlue) {
                    selfMesh.material = red;
                    isBlue = false;
                } else {
                    selfMesh.material = blue;
                    isBlue = true;
                }
                
                curSkip = frameSkip;
            }
        } else {
            // if (!selfMesh.enabled) {
            //     selfMesh.enabled = true;
            // }
            if (!isBlue) {
                    selfMesh.material = blue;
                    isBlue = true;
                }
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = -Input.GetAxis("Vertical");
        //transform.Translate(Vector3.x * Time.deltaTime * speed * horizontalInput);
        transform.position = new Vector3(transform.position.x + Time.deltaTime * speed * horizontalInput, transform.position.y, transform.position.z);
        //transform.Translate(Vector3.z * Time.deltaTime * speed * verticalInput);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * speed * verticalInput);

        screenCenterX = Screen.width / 2;
        screenCenterY = Screen.height / 2;
        mousePos = Input.mousePosition;
        rocketTimer -= Time.deltaTime;
        // if the mouse is in the window
        if (mousePos.x > 0.0f && mousePos.x < Screen.width && mousePos.y > 0.0f && mousePos.y < Screen.height) {
            widthLength = screenCenterX - mousePos.x;
            heightLength = screenCenterY - mousePos.y;
            float h = Input.mousePosition.x - screenCenterX;
            float v = Input.mousePosition.y - screenCenterY;
            float angle = -Mathf.Atan2(v,h) * Mathf.Rad2Deg;

            // Debug.Log(angle);
            transform.rotation = Quaternion.Euler(270, angle, 0);

            if (Input.GetMouseButton(0) && rocketTimer < 0f) {
                spawnedRocket = Instantiate(rocket, transform.position, Quaternion.Euler(0, angle + 90, 0)) as GameObject;

                spawnedRocket.GetComponent<RocketScript>().allegiance = true;
                rocketTimer = 0.2f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {

        }
    }

    public void decreaseHealth(int damage) {
        if (invulnerabilityTimer < 0.1f) {
            health -= damage;
            healthText.text = "Health: " + health;
            invulnerabilityTimer = 5f;
        }
    }
}
